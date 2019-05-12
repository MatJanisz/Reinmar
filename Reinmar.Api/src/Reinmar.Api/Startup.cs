using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Reinmar.Infrastructure.DataAccess;
using Reinmar.Infrastructure.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Reinmar.Api
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddDbContext<ReinmarDbContext> (dbOptions =>
                dbOptions.UseSqlServer (Configuration.GetConnectionString ("ReinmarConnectionString"), b => b.MigrationsAssembly ("Reinmar.Api"))
            );

            services.AddSwaggerGen (c =>
            {
                c.SwaggerDoc ("v1", new Info { Title = "Reinmar API", Version = "v1" });
            });

            services.AddCors (options =>
            {
                options.AddPolicy ("AllowAll", builder =>
                    builder.AllowAnyOrigin ()
                    .AllowAnyHeader ()
                    .AllowAnyMethod ());
            });

            services.ConfigureJwt (Configuration);

            services
                .AddMvc ()
                .AddJsonOptions (options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver ();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });;
            services.RegisterDependencies ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ReinmarDbContext dbContext)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }
            dbContext.Database.EnsureCreated();

            app.UseSwagger ();

            app.UseSwaggerUI (c =>
            {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication ();

            app.UseMvc ();

            app.UseCors ("AllowAll");

            app.Run (async (context) =>
            {
                context.Response.Redirect ("swagger");
                await Task.FromResult (0);
            });
        }
    }
}