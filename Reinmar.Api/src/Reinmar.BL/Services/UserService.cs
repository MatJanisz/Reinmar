using Reinmar.BL.Interfaces;
using Reinmar.DA.Helpers;
using Reinmar.DA.Interfaces;
using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.BL.Services
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepository;
		private ITokenHelper _tokenHelper;
		public UserService(IUserRepository userRepository, ITokenHelper tokenHelper)
		{
			_userRepository = userRepository;
			_tokenHelper = tokenHelper;
		}
		public bool Add(User user)
		{
			return _userRepository.Add(user);
		}

		public IEnumerable<User> GetAll()
		{
			return _userRepository.GetAll();
		}

		public string LogIn(string email, string password)
		{
			if(!_userRepository.CheckLogIn(email, password))
			{
				return null;
			}
			return _tokenHelper.CreateToken(email);
		}
	}
}
