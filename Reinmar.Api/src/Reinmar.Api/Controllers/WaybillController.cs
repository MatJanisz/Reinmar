using System;
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
    public class WaybillController : Controller
    {
        private IWaybillService _service;
        public WaybillController(IWaybillService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public void Create(Waybill waybill)
        {
            _service.Create(waybill);
        }
        [HttpPost]
        [Route("[action]")]

        public Waybill GetWaybillsById([FromBody]Guid id)
        {
            return _service.GetWaybillsById(id);
        }

        [HttpPost]
        [Route("[action]")]
        public Waybill GetWaybillsBySitId([FromBody]int sitId)
        {
            return _service.GetWaybillsBySitId(sitId);
        }
    }
}