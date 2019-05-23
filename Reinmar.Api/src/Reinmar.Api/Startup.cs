using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reinmar.BL.Interfaces;
using Reinmar.BL.Services;
using Reinmar.DA.DataAccess;
using Reinmar.DA.Helpers;
using Reinmar.DA.Interfaces;
using Reinmar.DA.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Reinmar.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});
			services.AddAuthentication(
			   options =>
			   {
				   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			   })
		  .AddJwtBearer(options =>
		  {
			  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
			  {
				  ValidateIssuer = true,
				  ValidateAudience = true,
				  ValidateLifetime = true,
				  ValidateIssuerSigningKey = true,
				  ValidIssuer = Configuration["Jwt:Issuer"],
				  ValidAudience = Configuration["Jwt:Issuer"],
				  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
			  };
		  });
			services.AddDbContext<ReinmarDbContext>(dbOptions =>
			   dbOptions.UseSqlServer(Configuration.GetConnectionString("ReinmarConnectionString"))
			);
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ITokenHelper, TokenHelper>();
			services.AddTransient<IPackageService, PackageService>();
			services.AddTransient<IPackageRepository, PackageRepository>();
			services.AddTransient<IPasswordHelper, PasswordHelper>();

			services.AddMvc();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "QuickBuy.Api", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
				c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
				{ "Bearer", Enumerable.Empty<string>() },
			});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseMvc();
			app.UseCors("AllowAll");
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reinmar.Api v1");
				c.RoutePrefix = string.Empty;
			});
			app.Run(async (context) =>
			{
				context.Response.Redirect("index.html");
				await Task.FromResult(0);
			});
		}
	}
}
