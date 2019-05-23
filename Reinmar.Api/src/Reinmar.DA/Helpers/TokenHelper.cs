using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reinmar.DA.Helpers
{
	public class TokenHelper : ITokenHelper
	{
		private IConfiguration _config;
		public TokenHelper(IConfiguration configuration)
		{
			_config = configuration;
		}
		public string CreateToken(string email)
		{
			var claims = new[] {
				new Claim(JwtRegisteredClaimNames.Email, email)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_config["Jwt:Issuer"],
			  _config["Jwt:Issuer"],
			  claims,
			  expires: DateTime.Now.AddHours(10),
			  signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
