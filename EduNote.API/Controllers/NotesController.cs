using AutoMapper;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using EduNote.API.Shared.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;


namespace EduNote.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public NotesController(IRepository dataService, IOptions<AppSettings> appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
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
                Note note = _dataService.GetById<Note>(id);

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
                    User user = _dataService.GetById<User>(1);
                    note.CreatedBy = user;
                    note.ModifiedBy = user;

                    return StatusCode(200, _dataService.Create(note));
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
                    User user = _dataService.GetById<User>(1);
                    Note note = _dataService.GetById<Note>(id);
                    note.ModifiedBy = user;

                    Mapper.Map(model, note);

                    _dataService.Update(note);

                    return StatusCode(200, _dataService.Update(note));
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
                Note note = _dataService.GetById<Note>(id);

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