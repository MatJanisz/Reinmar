using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
         User GetByDomain(string domain);

         bool CheckLogIn(string username, string password);
    }
}