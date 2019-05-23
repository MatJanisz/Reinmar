using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Reinmar.BL.Interfaces;
using Reinmar.DA.Models;

namespace Reinmar.Api.Controllers
{
	[EnableCors("AllowAll")]
	[Route("api/[controller]")]
	public class UserController : Controller
    {
		private IUserService _userService;
		public UserController(IUserService service)
		{
			_userService = service;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_userService.GetAll());
		}
		[HttpPost]
		public IActionResult Register([FromBody] User user)
		{
			if (_userService.Add(user))
			{
				return Ok();
			}
			return BadRequest();
		}
		[HttpPost("login")]
		public IActionResult LogIn([FromBody] User user)
		{
			string q = user.Email;
			string w = user.Password;
			var token = _userService.LogIn(user.Email, user.Password);
			if (token == null)
			{
				return Unauthorized();
			}
			return Ok(new { token = _userService.LogIn(user.Email, user.Password) });

		}
	}
}