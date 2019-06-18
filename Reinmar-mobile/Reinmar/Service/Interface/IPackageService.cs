using System.Threading.Tasks;
using Reinmar.ApiModel;
using Reinmar.Model;

namespace Reinmar.Service.Interface
{
    public interface IPackageService
    {
        //Task<GetPackageResponse> GetPackage(int sitId, string token);

        Task<PackageModel> GetPackage(string sitId, string token);

        Task<Enums.Status> ChangeStatus(string sitId, string location, string statusEevent, string token);
    }
}
