using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Repositories.Interfaces
{
    public interface IWaybillRepository : IRepository<Waybill>
    {
         Waybill GetBySitId(int sitId);
    }
}