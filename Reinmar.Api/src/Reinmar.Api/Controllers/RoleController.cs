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
    public class RoleController : Controller
    {
        private IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public void Add([FromBody]Role entity)
        {
            _service.Add(entity);
        }
        [HttpPost]
        [Route("[action]")]
        public void Delete([FromBody]Role entity)
        {
            _service.Delete(entity);
        }
        [HttpPost]
        [Route("[action]")]
        public void Edit([FromBody]Role entity)
        {
            _service.Edit(entity);
        }
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Role> GetAll()
        {
            return _service.GetAll();
        }
        [HttpPost]
        [Route("[action]")]
        public IEnumerable<Role> GetByDomain([FromBody]string domain)
        {
            return _service.GetByDomain(domain);
        }
        [HttpPost]
        [Route("[action]")]
        public Role GetById([FromBody]int id)
        {
            return _service.GetById(id);
        }
    }
}