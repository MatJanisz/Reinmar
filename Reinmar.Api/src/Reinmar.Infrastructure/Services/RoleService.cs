using System.Collections.Generic;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }        
        public void Add(Role entity)
        {
            _roleRepository.Add(entity);
        }

        public void Delete(Role entity)
        {
            _roleRepository.Delete(entity);
        }

        public void Edit(Role entity)
        {
            _roleRepository.Edit(entity);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public IEnumerable<Role> GetByDomain(string domain)
        {
            return _roleRepository.GetByDomain(domain);
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }
    }
}