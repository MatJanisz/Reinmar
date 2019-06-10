using Reinmar.DA.DataAccess;
using Reinmar.DA.Interfaces;
using Reinmar.DA.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Reinmar.DA.Helpers.Interfaces;

namespace Reinmar.DA.Repositories
{
	public class PackageRepository : IPackageRepository
	{
		private ReinmarDbContext _context;
		private IEmailHelper _emailHelper;
		public PackageRepository(ReinmarDbContext context, IEmailHelper emailHelper)
		{
			_context = context;
			_emailHelper = emailHelper;
			_context.Database.EnsureCreated();
		}
		public string Add(Package package, string senderEmail)
		{
			Random random = new Random();
			const string chars = "012345678912789";
			string sitId;
			bool isIdPresent = false;
			do
			{
				sitId = new string(Enumerable.Repeat(chars, chars.Length)
					.Select(s => s[random.Next(s.Length)]).ToArray());
				var existingPackage = _context.Packages.SingleOrDefault(x => x.SitId == sitId);
				if (existingPackage != null)
				{
					isIdPresent = true;
				}
			}
			while (isIdPresent);

			var sender = _context.Users.Single(s => s.Email == senderEmail);
			package.SenderId = sender.Id;
			package.SitId = sitId;
			_context.Packages.Add(package);
			_context.SaveChanges();
			_emailHelper.SendEmail(package.ReceiverEmail, package, "", "addReceiver");
			_emailHelper.SendEmail(senderEmail, package, "", "addSender");
			return sitId;
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
			var sender = _context.Users.Single(x => x.Id == package.SenderId);
			if (status.Event.ToLower() == "delivered")
			{
				_emailHelper.SendEmail(package.ReceiverEmail, package, status.Event + ", " + status.Location, "finalReceiver");
				_emailHelper.SendEmail(sender.Email, package, status.Event + ", " + status.Location, "finalSender");
			}
			else
			{
				_emailHelper.SendEmail(package.ReceiverEmail, package, status.Event + ", " + status.Location, "");
				_emailHelper.SendEmail(sender.Email, package, status.Event + ", " + status.Location, "");
			}
		}

		public Status GetLatestStatus(string sitId)
		{
			var package = _context.Packages.Include(s => s.Statuses).SingleOrDefault(s => s.SitId == sitId);
			return package.Statuses.OrderByDescending(d => d.Date).FirstOrDefault();
		}
	}
}
