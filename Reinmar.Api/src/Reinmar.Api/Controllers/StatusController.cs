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
    public class StatusController : Controller
    {
        private IStatusService _service;
        public StatusController(IStatusService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public void Add([FromBody]Status entity)
        {
            _service.Add(entity);
        }
        [HttpPost]
        [Route("[action]")]
        public void Edit([FromBody]Status entity)
        {
            _service.Edit(entity);
        }
    }
}