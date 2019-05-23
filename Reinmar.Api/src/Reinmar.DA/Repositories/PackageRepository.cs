using Reinmar.DA.DataAccess;
using Reinmar.DA.Interfaces;
using Reinmar.DA.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Reinmar.DA.Repositories
{
	public class PackageRepository : IPackageRepository
	{
		private ReinmarDbContext _context;
		public PackageRepository(ReinmarDbContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}
		public void Add(Package package, string senderEmail)
		{
			var sender = _context.Users.Single(s => s.Email == senderEmail);
			package.SenderId = sender.Id;
			_context.Packages.Add(package);
			_context.SaveChanges();
		}

		public IEnumerable<Package> GetAll()
		{
			return  _context.Packages.Include(s => s.Statuses).ToList();
		}

		public Package GetBySidId(string sitId)
		{
			return _context.Packages.Include(s => s.Statuses).Single(s => s.SitId == sitId);
		}

		public void ChangeStatus(string sitId, Status status)
		{
			var package = _context.Packages.Include(s => s.Statuses).SingleOrDefault(s => s.SitId == sitId);
			var newStatus = new Status(status.Location, status.Event);
			package.Statuses.Add(newStatus);
			_context.SaveChanges();
		}

		public Status GetLatestStatus(string sitId)
		{
			var package = _context.Packages.Include(s => s.Statuses).SingleOrDefault(s => s.SitId == sitId);
			return package.Statuses.OrderByDescending(d => d.Date).FirstOrDefault();
		}
	}
}
