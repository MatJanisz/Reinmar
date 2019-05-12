using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Helpers.Interfaces;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IPasswordHelper _passwordHelper;
        public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }

        public void Create(User newUser)
        {
            newUser.Password = _passwordHelper.EncryptPassword(newUser.Password);
            _userRepository.Add(newUser);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetByDomain(string domain)
        {
            return _userRepository.GetByDomain(domain);
        }

        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(User user)
        {
            _userRepository.Edit(user);
        }
    }
}