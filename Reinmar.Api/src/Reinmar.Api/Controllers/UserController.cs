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
    public class UserController : Controller
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public void Create([FromBody]User newUser)
        {
            _service.Create(newUser);
        }
        [HttpPost]
        [Route("[action]")]
        public void Delete([FromBody]User user)
        {
            _service.Delete(user);
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<User> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Route("[action]")]
        public User GetByDomain([FromBody]string domain)
        {
            return _service.GetByDomain(domain);
        }

        [HttpPost]
        [Route("[action]")]
        public User GetById([FromBody]Guid id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void Update([FromBody]User user)
        {
            _service.Update(user);
        }
    }
}