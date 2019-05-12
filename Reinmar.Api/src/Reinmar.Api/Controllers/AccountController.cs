using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reinmar.Api.Requests;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("/api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult LogIn([FromBody]LoginRequest request)
        {
            try
            {
                var token =_service.LogIn(request.Login,request.Password);
                return Ok(new {token = token});
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}