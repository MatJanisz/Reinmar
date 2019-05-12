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
    public class WaybillBodyController : Controller
    {
        private IWaybillBodyService _service;
        public WaybillBodyController(IWaybillBodyService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public WaybillBody Create([FromBody]WaybillBody waybillBodies)
        {
            return _service.Create(waybillBodies);
        }

        [HttpPost]
        [Route("[action]")]        
        public void Delete([FromBody]WaybillBody entity)
        {
            _service.Delete(entity);
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WaybillBody> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Route("[action]")]
        public IEnumerable<WaybillBody> GetByHeaderId([FromBody]Guid id)
        {
            return _service.GetByHeaderId(id);
        }

        [HttpPost]
        [Route("[action]")]
        public WaybillBody GetById([FromBody]Guid id)
        {
            return _service.GetById(id);
        }

        [HttpGet]
        [Route("[action]/{sitid}")]
        public IEnumerable<WaybillBody> GetBySitId(int sitId)
        {
            Console.WriteLine(sitId);
            return _service.GetBySitId(sitId);
        }

        [HttpPost]
        [Route("[action]")]
        public void Update([FromBody]WaybillBody entity)
        {
            _service.Update(entity);
        }
    }
}