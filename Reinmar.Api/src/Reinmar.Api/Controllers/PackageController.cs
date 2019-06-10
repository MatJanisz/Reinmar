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
		public string Add([FromBody] Package package)
        {
			var currentUser = HttpContext.User;
			var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
			return _packageService.Add(package, email);
        }

		[HttpGet]
		public IEnumerable<Package> Get()
		{
			var packages = _packageService.GetAll();
			return _packageService.GetAll();
		}

		[HttpGet("GetBySitId/{sitId}")]
		public Package GetBySitId(string sitId)
		{
			return _packageService.GetBySidId(sitId);
		}

		[HttpPost("ChangeStatus/{sitId}")]
		public IActionResult ChangeStatus(string sitId, [FromBody] Status status)
		{
			_packageService.ChangeStatus(sitId, status);
			return Ok();
		}

		[HttpGet("GetByLatestStatus/{sitId}")]
		public Status GetByLatestStatus(string sitId)
		{
			return _packageService.GetLatestStatus(sitId);
		}
	}
}