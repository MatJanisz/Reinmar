using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.BL.Interfaces
{
	public interface IPackageService
	{
		string Add(Package package, string emailSender);
		IEnumerable<Package> GetAll();
		Package GetBySidId(string sitId);
		void ChangeStatus(string sitId, Status status);
		Status GetLatestStatus(string sitId);
		IEnumerable<Package> GetMyPackages(string senderEmail);
	}
}
