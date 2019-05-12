using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Repositories.Interfaces;

namespace Reinmar.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ReinmarDbContext _context;
        public RoleRepository(ReinmarDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(Role entity)
        {
            _context.Entry(entity.User).State = EntityState.Modified;

            _context.Roles
                .Add(entity);

            _context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _context.Roles.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles
                .ToList();
        }

        public IEnumerable<Role> GetByDomain(string domain)
        {
            return _context.Roles
                .Where(x => x.User.Domain == domain)
                .ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles
                .FirstOrDefault(x => x.Id == id);
        }
    }
}