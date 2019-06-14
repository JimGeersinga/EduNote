using AutoMapper;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using EduNote.API.Shared.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public virtual IActionResult Get()
        {
            try
            {
                IEnumerable<Section> items = _dataService.GetAll<Section>();

                return Ok(Mapper.Map<List<SectionListDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
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
        public override IActionResult Get(long id)
        {
            try
            {
                Section item = _dataService.GetById<Section>(id, x => x.Sections, x => x.Questions, x => x.Notes);
                item.Questions.ToList().ForEach(x =>
                {
                    x.CreatedBy = _dataService.Get<User>(z => z.Id == x.CreatedById).FirstOrDefault();
                });
                return StatusCode(200, Mapper.Map<SectionDetailDTO>(item));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}/questions")]
        public IActionResult GetSectionQuestions(long id, string search = null, bool selfOnly = false)
        {
            try
            {
                User user = GetAuthenticatedUser();
                IEnumerable<Question> items = _dataService.Get<Question>(x =>
                    x.SectionId == id &&
                    (!selfOnly || x.CreatedById == user.Id) &&
                    (string.IsNullOrWhiteSpace(search) || x.Title.ToLower().Contains(search.ToLower())), includes: x => x.Answers);

                items.ToList().ForEach(x =>
                {
                    x.CreatedBy = _dataService.Get<User>(z => z.Id == x.CreatedById).FirstOrDefault();
                });
                return StatusCode(200, Mapper.Map<List<QuestionDetailDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}/notes")]
        public IActionResult GetSectionNotes(long id, string search = null, bool selfOnly = false)
        {
            try
            {
                User user = GetAuthenticatedUser();
                IEnumerable<Note> items = _dataService.Get<Note>(x =>
                    x.SectionId == id &&
                    (!selfOnly || x.CreatedById == user.Id) &&
                    (string.IsNullOrWhiteSpace(search) || x.Title.ToLower().Contains(search.ToLower())));

                items.ToList().ForEach(x =>
                {
                    x.CreatedBy = _dataService.Get<User>(z => z.Id == x.CreatedById).FirstOrDefault();
                });
                return StatusCode(200, Mapper.Map<List<NoteDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}