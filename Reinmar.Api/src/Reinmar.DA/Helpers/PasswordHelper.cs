using Reinmar.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Reinmar.DA.Helpers
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
