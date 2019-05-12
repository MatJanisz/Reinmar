using Microsoft.Extensions.DependencyInjection;
using Reinmar.Infrastructure.Helpers;
using Reinmar.Infrastructure.Helpers.Interfaces;
using Reinmar.Infrastructure.Repositories;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Extensions
{
    public static class RegisterExtension
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHelper,PasswordHelper>();
            services.AddScoped<ITokenHelper,TokenHelper>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IStatusRepository,StatusRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IWaybillRepository,WaybillRepository>();
            services.AddScoped<IWaybillBodyRepository,WaybillBodyRepository>();
            services.AddScoped<IWaybillHeaderRepository,WaybillHeaderRepository>();
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<IStatusService,StatusService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IWaybillService,WaybillService>();
            services.AddScoped<IWaybillBodyService,WaybillBodyService>();
            services.AddScoped<IWaybillHeaderService,WaybillHeaderService>();
            services.AddScoped<IAccountService,AccountService>();
        }
    }
}