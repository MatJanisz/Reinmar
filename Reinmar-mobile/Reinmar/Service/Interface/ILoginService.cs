using System.Threading.Tasks;
using Reinmar.ApiModel;

namespace Reinmar.Service.Interface
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(string login, string password);
    }
}
