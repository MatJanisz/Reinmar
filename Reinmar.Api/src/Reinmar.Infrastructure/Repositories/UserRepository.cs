using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Repositories.Interfaces;

namespace Reinmar.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ReinmarDbContext _context;
        public UserRepository(ReinmarDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public bool CheckLogIn(string username, string password)
        {
            return _context.Users.Where(x=>x.Name.Equals(username) && x.Password.Equals(password)).Any();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByDomain(string domain)
        {
            return _context.Users.Include("Roles").FirstOrDefault(x => x.Domain == domain);
        }

        public User GetById(Guid id)
        {
            return _context.Users.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }
    }
}