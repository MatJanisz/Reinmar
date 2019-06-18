using System.Threading.Tasks;
using Reinmar.Common.Entities;

namespace Reinmar.Service.Interface
{
    public interface IStatusService
    {
        Task<Enums.Status> AddStatus(WaybillBody waybillBody, string statusEvent, string token);
    }
}
