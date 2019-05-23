using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.Interfaces
{
	public interface IPackageRepository
	{
		void Add(Package package, string senderEmail);
		IEnumerable<Package> GetAll();
		Package GetBySidId(string sitId);
		void ChangeStatus(string sitId, Status status);
		Status GetLatestStatus(string sitId);
	}
}
