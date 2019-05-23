using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.BL.Interfaces
{
	public interface IUserService
	{
		bool Add(User user);
		IEnumerable<User> GetAll();
		string LogIn(string email, string password);
	}
}
