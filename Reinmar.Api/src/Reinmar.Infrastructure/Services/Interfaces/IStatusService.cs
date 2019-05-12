using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Services.Interfaces
{
    public interface IStatusService
    {
         void Add(Status entity);
         void Edit(Status entity);
    }
}