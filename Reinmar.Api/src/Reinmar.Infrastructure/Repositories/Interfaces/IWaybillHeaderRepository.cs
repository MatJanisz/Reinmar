using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Repositories.Interfaces
{
    public interface IWaybillHeaderRepository : IRepository<WaybillHeader>
    {
         WaybillHeader GetBySitId(int sitId);
         
    }
}