using System;
using System.Security.Cryptography;
using System.Text;
using Reinmar.Infrastructure.Helpers.Interfaces;

namespace Reinmar.Infrastructure.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        public string EncryptPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var passwordStream = Encoding.UTF8.GetBytes(password);
            var hashedPassword = md5.ComputeHash(passwordStream);
            var hashedPasswordString = BitConverter.ToString(hashedPassword).Replace("-", "");
            return hashedPasswordString;
        }
    }
}