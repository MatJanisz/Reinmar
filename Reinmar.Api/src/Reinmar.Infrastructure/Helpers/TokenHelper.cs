using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reinmar.Infrastructure.Helpers.Interfaces;

namespace Reinmar.Infrastructure.Helpers 
{
    public class TokenHelper : ITokenHelper 
    {
        private IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public TokenHelper (IConfiguration configuration) 
        {
            _configuration = configuration;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public string CreateToken () 
        {
            var token = GenerateToken();
            
            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        private JwtSecurityToken GenerateToken()
        {
            return new JwtSecurityToken (
                claims : GetTokenClaims(),
                expires : DateTime.UtcNow.AddHours(12),
                signingCredentials : new SigningCredentials (new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_configuration["Key"])), SecurityAlgorithms.HmacSha256),
                audience: _configuration["Audience"],
                issuer: _configuration["Issuer"]
            );
        }

        private IEnumerable<Claim> GetTokenClaims () 
        {
            return new List<Claim>()
            {
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ())
            };
        }
    }
}