using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Services.Interfaces 
{
    public interface IUserService 
    {
        User GetByDomain (string domain);

        void Create (User newUser);

        void Update (User user);

        IEnumerable<User> GetAll ();
        User GetById (Guid id);
        void Delete (User user);
    }
}