using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Repositories.Interfaces
{
    public interface IStatusRepository
    {
         void Add(Status entity);
         void Edit(Status entity);
    }
}