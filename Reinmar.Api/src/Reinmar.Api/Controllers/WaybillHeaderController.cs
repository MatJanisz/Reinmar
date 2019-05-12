using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Authorize]
    [Route("api/[controller]")]
    public class WaybillHeaderController : Controller
    {
        private IWaybillHeaderService _service;
        public WaybillHeaderController(IWaybillHeaderService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public void Create([FromBody]WaybillHeader entity)
        {
            _service.Create(entity);
        }

        [HttpPost]
        [Route("[action]")]
        public void Delete([FromBody]WaybillHeader entity)
        {
            _service.Delete(entity);
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WaybillHeader> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Route("[action]")]
        public WaybillHeader GetById([FromBody]Guid id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        [Route("[action]")]
        public WaybillHeader GetBySitId([FromBody]int sitId)
        {
            return _service.GetBySitId(sitId);
        }
        [HttpPost]
        [Route("[action]")]
        public void Update([FromBody]WaybillHeader entity)
        {
            _service.Update(entity);
        }
    }
}