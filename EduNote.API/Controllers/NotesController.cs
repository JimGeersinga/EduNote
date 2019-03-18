﻿using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using EduNote.API.Shared.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


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
    }
}