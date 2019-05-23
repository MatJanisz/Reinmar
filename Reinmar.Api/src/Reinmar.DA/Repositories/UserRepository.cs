using Reinmar.DA.DataAccess;
using Reinmar.DA.Interfaces;
using Reinmar.DA.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.Repositories
{
	public class UserRepository : IUserRepository
	{
		private ReinmarDbContext _context;
		private IPasswordHelper _passwordHelper;
		public UserRepository(ReinmarDbContext context, IPasswordHelper passwordHelper)
		{
			_context = context;
			_passwordHelper = passwordHelper;
			_context.Database.EnsureCreated();
		}
		public bool Add(User user)
		{
			if (_context.Users.SingleOrDefault(u => u.Email == user.Email) != null) 
			{
				return false;
			}
			user.Password = _passwordHelper.EncryptPassword(user.Password);
			_context.Add(user);
			_context.SaveChanges();
			return true;
		}

		public bool CheckLogIn(string email, string password)
		{
			password = _passwordHelper.EncryptPassword(password);
			return _context.Users.Where(u => u.Email == email && u.Password == password).Any();
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users.ToList();
		}

		public User GetUserByEmail(string email)
		{
			return _context.Users.SingleOrDefault(e => e.Email == email);
		}
	}
}
