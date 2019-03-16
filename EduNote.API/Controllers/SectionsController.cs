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
    public class SectionsController : BaseController<Section, SectionListDTO, SectionDetailDTO>
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public SectionsController(IRepository dataService, IOptions<AppSettings> appSettings) : base(dataService, appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Route("root")]
        public virtual IActionResult Root()
        {
            try
            {
                IEnumerable<Section> items = _dataService.Get<Section>(x => x.ParentId == null);

                return Ok(Mapper.Map<List<SectionListDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public override IActionResult Get(int id)
        {
            try
            {
                Section item = _dataService.GetById<Section>(id, x => x.Sections, x => x.Questions, x => x.Notes);

                return StatusCode(200, Mapper.Map<SectionDetailDTO>(item));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}