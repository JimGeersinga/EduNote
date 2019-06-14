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
    public class TagsController : BaseController<Tag, TagDTO, TagDTO>
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public TagsController(IRepository dataService, IOptions<AppSettings> appSettings) : base(dataService, appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                IEnumerable<Tag> items = _dataService.GetAll<Tag>();

                return Ok(Mapper.Map<List<TagDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}