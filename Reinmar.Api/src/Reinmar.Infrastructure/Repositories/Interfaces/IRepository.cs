using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
         TEntity GetById(Guid id);

         IEnumerable<TEntity> GetAll();

         void Add(TEntity entity);

         void Edit(TEntity entity);

         void Delete(TEntity entity);
    }
}