using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Reinmar.Infrastructure.Extensions
{
    public static class JwtExtension
    {
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>{
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>{
                config.TokenValidationParameters = new TokenValidationParameters(){
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"])),
                    ValidIssuer = configuration["Issuer"],
                    ValidAudience = configuration["Audience"],
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                };
            });
        }
    }
}