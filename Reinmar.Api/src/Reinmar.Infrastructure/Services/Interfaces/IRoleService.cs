using System.Collections.Generic;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Services.Interfaces
{
    public interface IRoleService
    {
         Role GetById(int id);
         IEnumerable<Role> GetAll();
         void Add(Role entity);
         void Edit(Role entity);
         void Delete(Role entity);
         IEnumerable<Role> GetByDomain(string domain);
    }
}