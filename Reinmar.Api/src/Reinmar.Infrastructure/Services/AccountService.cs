using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Reinmar.Infrastructure.Helpers.Interfaces;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository _userRepository;
        private ITokenHelper _tokenHelper;
        private IPasswordHelper _passwordHelper;
        public AccountService(
            IUserRepository userRepository,
            ITokenHelper tokenHelper,
            IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _passwordHelper = passwordHelper;
        }
        public string LogIn(string username, string password)
        {
            if(!_userRepository.CheckLogIn(username,_passwordHelper.EncryptPassword(password))){
                throw new SecurityException();
            }

            return _tokenHelper.CreateToken();
        }
    }
}