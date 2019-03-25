using EduNote.API.EF.Helpers;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduNote.API.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public UserService(IRepository dataService, IOptions<AppSettings> appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string email, string password)
        {
            User user = _dataService.GetFirst<User>(x => x.Email == email);
            if (user == null)
            {
                return null;
            }

            if (!Encryption.Verify(password, user.Password))
            {
                return null;
            }

            user.Token = GenerateToken(user);

            return user;
        }       

        public string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
