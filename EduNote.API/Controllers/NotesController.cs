using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using EduNote.API.Shared.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace EduNote.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;

        public NotesController(IRepository dataService, IOptions<AppSettings> appSettings, UserManager<User> userManager)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try 
            {
                IEnumerable<Note> notes = _dataService.GetAll<Note>();

                return Ok(Mapper.Map<List<NoteAPIModel>>(notes));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try 
            {
                Note note = _dataService.GetById(id, ??????);

                return StatusCode(200, Mapper.Map<NoteAPIModel>(note));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteAPIModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Note note = Mapper.Map<Note>(model);
                    string userId = _userManager.GetUserId(HttpContext.User);
                    User user = _dataService.GetById<User>(userId, ???????);

                    return StatusCode(200, _dataService.Create(note, user));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e);
                }
            }

            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]NoteAPIModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string userId = _userManager.GetUserId(HttpContext.User);
                    User user = _dataService.GetById<User>(userId, ???????);
                    Note note = _dataService.GetById<Note>(id, ?????);

                    Mapper.Map(model, note);

                    _dataService.Update(note, user);

                    return StatusCode(200, _dataService.Create(note, user));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e);
                }
            }

            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Note note = _dataService.GetById(id, ??????);

                _dataService.Delete(note);

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}