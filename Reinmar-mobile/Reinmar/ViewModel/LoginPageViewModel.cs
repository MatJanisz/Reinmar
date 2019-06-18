using System.Threading.Tasks;
using Reinmar.Providers;
using Reinmar.Service.Interface;

namespace Reinmar.ViewModel
{
    public class LoginPageViewModel
    {
        private ILoginService _loginService;

        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<string> Login(string email, string password)
        {
            var token = await _loginService.Login(email, password);

            if(token == null)
            {
                return null;
            }

            TokenProvider.token = token.Token;
            return token.Token;
        }
    }
}
