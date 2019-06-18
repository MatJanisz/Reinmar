using System.Threading.Tasks;
using Reinmar.Common.Entities;

namespace Reinmar.Service.Interface
{
    public interface IWaybillBodyService
    {
        Task<WaybillBody> GetWaybillBody(int sitId, string token);
    }
}
