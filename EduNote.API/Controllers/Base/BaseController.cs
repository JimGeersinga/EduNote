using AutoMapper;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;


namespace EduNote.API.Controllers
{
    [Authorize]
    public abstract class BaseController<TEntity, TListEntityDTO, TDetailEntityDTO> : Controller
        where TEntity : class, IEntity
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public BaseController(IRepository dataService, IOptions<AppSettings> appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                IEnumerable<TEntity> items = _dataService.GetAll<TEntity>();

                return Ok(Mapper.Map<List<TListEntityDTO>>(items));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(long id)
        {
            try
            {
                TEntity item = _dataService.GetById<TEntity>(id);

                return StatusCode(200, Mapper.Map<TDetailEntityDTO>(item));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]TListEntityDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TEntity item = Mapper.Map<TEntity>(model);
                    return StatusCode(200, _dataService.Create(item));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e);
                }
            }
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(long id, [FromBody]TDetailEntityDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TEntity item = _dataService.GetById<TEntity>(id);
                    Mapper.Map(model, item);
                    _dataService.Update(item);
                    return StatusCode(200, _dataService.Update(item));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e);
                }
            }

            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(long id)
        {
            try
            {
                TEntity item = _dataService.GetById<TEntity>(id);

                _dataService.Delete(item);

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        protected User GetAuthenticatedUser()
        {
            return _dataService.GetFirst<User>(x => x.Email == User.Identity.Name);
        }
    }
}