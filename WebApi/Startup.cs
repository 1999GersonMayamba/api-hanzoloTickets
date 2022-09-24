using Application;
using Application.Interfaces;
using Application.Interfaces.NLog;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Shared;
using Infrastructure.Shared.Helpers;
using Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using WebApi.Extensions;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors();
            services.AddApplicationLayer();
			services.AddIdentityInfrastructure(_config);
			services.AddPersistenceInfrastructure(_config);
			services.AddSharedInfrastructure(_config);
			services.AddSwaggerExtension();
			services.AddControllers();
            services.AddApiVersioningExtension();
			services.AddHealthChecks();
			services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            var appBasePath = System.IO.Directory.GetCurrentDirectory();
           // NLog.GlobalDiagnosticsContext.Set("appbasepath", appBasePath);
            //LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
            services.AddSingleton<ILog, LogNLog>();
            // register PeerJs Server dependencies
            services.AddSignalR();
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
			app.UseSwaggerExtension();
			app.UseErrorHandlingMiddleware();
            //app.UseHealthChecks("/hc");
            //app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/hc", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    var response = new HealthCheckHelpers.HealthCheckResponse
                    {
                        Status = report.Status.ToString(),
                        Duration = report.TotalDuration,
                        Checks = report.Entries.Select(x => new HealthCheckHelpers.HealthCheck
                        {
                            Component = x.Key,
                            Status = x.Value.Status.ToString(),
                            Description = x.Value.Description
                        })
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                }
            });


        }
    }
}
