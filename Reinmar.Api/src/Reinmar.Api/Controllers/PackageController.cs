using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reinmar.BL.Interfaces;
using Reinmar.DA.Models;


namespace Reinmar.Api.Controllers
{
	[Authorize]
	[EnableCors("AllowAll")]
	[Route("api/[controller]")]
	public class PackageController : Controller
    {
		private IPackageService _packageService;
		public PackageController(IPackageService service)
		{
			_packageService = service;
		}

		[HttpPost]
		public IActionResult Add([FromBody] Package package)
        {
			var currentUser = HttpContext.User;
			var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
			_packageService.Add(package, email);
			return Ok();
        }

		[HttpGet]
		public IActionResult Get()
		{
			var packages = _packageService.GetAll();
			return Ok(_packageService.GetAll());
		}

		[HttpGet("GetBySitId/{sitId}")]
		public IActionResult GetBySitId(string sitId)
		{
			return Ok(_packageService.GetBySidId(sitId));
		}

		[HttpPost("ChangeStatus/{sitId}")]
		public IActionResult ChangeStatus(string sitId, [FromBody] Status status)
		{
			_packageService.ChangeStatus(sitId, status);
			return Ok();
		}

		[HttpGet("GetByLatestStatus/{sitId}")]
		public IActionResult GetByLatestStatus(string sitId)
		{
			return Ok(_packageService.GetLatestStatus(sitId));
		}
	}
}