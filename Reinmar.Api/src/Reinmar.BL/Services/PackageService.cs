using Reinmar.BL.Interfaces;
using Reinmar.DA.Interfaces;
using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.BL.Services
{
	public class PackageService : IPackageService
	{
		private IPackageRepository _packageRepository;
		public PackageService(IPackageRepository packageRepository)
		{
			_packageRepository = packageRepository;
		}
		public void Add(Package package, string emailSender)
		{
			_packageRepository.Add(package, emailSender);
		}
		public IEnumerable<Package> GetAll()
		{
			var abc = _packageRepository.GetAll();
			return abc;
		}
		public Package GetBySidId(string sitId)
		{
			return _packageRepository.GetBySidId(sitId);
		}

		public void ChangeStatus(string sitId, Status status)
		{
			_packageRepository.ChangeStatus(sitId, status);
		}

		public Status GetLatestStatus(string sitId)
		{
			return _packageRepository.GetLatestStatus(sitId);
		}
	}
}
