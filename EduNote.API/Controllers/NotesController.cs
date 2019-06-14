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
    public class NotesController : BaseController<Note, NoteDTO, NoteDTO>
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public NotesController(IRepository dataService, IOptions<AppSettings> appSettings) : base(dataService, appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Get(string search = null, bool selfOnly = false)
        {
            try
            {
                User user = GetAuthenticatedUser();
                IEnumerable<Note> items = _dataService.Get<Note>(x =>
                    (!selfOnly || x.CreatedById == user.Id) && 
                    (string.IsNullOrWhiteSpace(search) || x.Title.ToLower().Contains(search.ToLower())));

                return Ok(Mapper.Map<List<NoteDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}