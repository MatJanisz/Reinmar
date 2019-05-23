using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.Interfaces
{
	public interface IUserRepository
	{
		bool Add(User user);
		IEnumerable<User> GetAll();
		User GetUserByEmail(string user);
		bool CheckLogIn(string login, string password);
	}
}
