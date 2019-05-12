using System.IdentityModel.Tokens.Jwt;

namespace Reinmar.Infrastructure.Services.Interfaces
{
    public interface IAccountService
    {
         string LogIn(string username, string password);
    }
}