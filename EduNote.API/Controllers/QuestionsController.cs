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
    public class QuestionsController : BaseController<Question, QuestionListDTO, QuestionDetailDTO>
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public QuestionsController(IRepository dataService, IOptions<AppSettings> appSettings) : base(dataService, appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Get(string search, bool selfOnly)
        {
            try
            {
                User user = GetAuthenticatedUser();
                IEnumerable<Question> items = _dataService.Get<Question>(x =>
                    (!selfOnly || x.CreatedById == user.Id) &&
                    (string.IsNullOrWhiteSpace(search) || x.Title == search));

                return Ok(Mapper.Map<List<QuestionListDTO>>(items));
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
                Question item = _dataService.GetById<Question>(id, x => x.Answers);

                return StatusCode(200, Mapper.Map<QuestionDetailDTO>(item));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}