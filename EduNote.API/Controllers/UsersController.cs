using AutoMapper;
using EduNote.API.EF.Helpers;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using EduNote.API.Services;
using EduNote.API.Shared.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

namespace EduNote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, UserListDTO, UserDetailDTO>
    {
        private readonly IRepository _dataService;
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(IRepository dataService, IUserService userService, IOptions<AppSettings> appSettings) : base(dataService, appSettings)
        {
            _dataService = dataService;
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpGet("current")]
        public virtual IActionResult Current()
        {
            try
            {
                User item = _dataService.GetFirst<User>(x => x.Email == User.Identity.Name, x => x.QuestionsCreated, x => x.NotesCreated, x => x.AnswersCreated, x => x.UserGroups);

                return StatusCode(200, Mapper.Map<UserDetailDTO>(item));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e);
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(Auth model)
        {
            try
            {
                User user = _userService.Authenticate(model.Email, model.Password);

                if (user == null)
                {
                    return BadRequest(new { message = "Email or password is incorrect" });
                }

                return Ok(new
                {
                    token = user.Token,
                    expirationTime = DateTime.UtcNow.AddDays(7),
                    refreshToken = user.RefreshToken
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        public IActionResult Refresh(string token, string refreshToken)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal principal = _userService.GetPrincipalFromExpiredToken(token);
                string email = principal.Identity.Name;
                string savedRefreshToken = _userService.GetRefreshToken(email); //retrieve the refresh token from a data store
                if (savedRefreshToken != refreshToken)
                {
                    throw new SecurityTokenException("Invalid refresh token");
                }

                string newJwtToken = _userService.GenerateToken(principal.Claims);
                string newRefreshToken = _userService.GenerateRefreshToken();
                _userService.UpdateRefreshToken(email, newRefreshToken);

                return Ok(new
                {
                    token = newJwtToken,
                    expirationTime = DateTime.UtcNow.AddDays(7),
                    refreshToken = newRefreshToken
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("{id}/updatepassword")]
        public IActionResult UpdatePassword(long id, PasswordDTO model)
        {
            try
            {
                User user = _dataService.GetById<User>(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Password = Encryption.HashPassword(model.Password);

                _dataService.Update(user);

                return Ok(Mapper.Map<UserDetailDTO>(user));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDTO model)
        {
            try
            {
                User user = _dataService.GetFirst<User>(x => x.Email == model.Email);
                if (user != null)
                {
                    return BadRequest(new { message = "This user already exists" });
                }

                user = Mapper.Map<User>(model);

                user.Password = Encryption.HashPassword(model.Password);

                _dataService.Create(user);

                return Ok(Mapper.Map<UserDetailDTO>(user));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}