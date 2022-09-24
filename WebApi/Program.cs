using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Domain.Identity.Entities;
using Application.Interfaces.Services.Permissoes;
using Application.Interfaces.Repositories;

namespace WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();



            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
               // var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    //Seeds para grupoPermissoes e Permissoes
                    var grupoPermissoesService = services.GetRequiredService<IGruposPermissoesService>();
                    var permissoesService = services.GetRequiredService<IPermissoesService>();
                    var provinciaRepository = services.GetRequiredService<IProvinciaRepository>();
                    var municipioRepository = services.GetRequiredService<IMunicipioRepository>();
                    var dominioRepository = services.GetRequiredService<IDominioRepository>();
                    var unidadeRepository = services.GetRequiredService<IUnidadeRepository>();
                    var grupoSexoRepository = services.GetRequiredService<IGrupoSexoRepository>();
                    var departamentoRepository = services.GetRequiredService<IDepartamentoRepository>();
                    var especialidadeMedicaRepository = services.GetRequiredService<IEspecialidadeMedicaRepository>();
                    var prioridadeRepository = services.GetRequiredService<IPrioridadeRepository>();
                    var projectoRepository = services.GetRequiredService<IProjectoRepository>();
                    var estadoManutencaoRepository = services.GetRequiredService<IEstadoManutencaoRepository>();
                    var origemManutencaoRepository = services.GetRequiredService<IOrigemManutencaoRepository>();
                    var tipoUnidadeRepository = services.GetRequiredService<ITipoUnidadeRepository>();
                    var prestadorRepository = services.GetRequiredService<IPrestadorRepository>();
                    var zonaRepository = services.GetRequiredService<IZonaRepository>();
                    var comunaRepository = services.GetRequiredService<IComunaRepository>();


                    //var doencaRepository = services.GetRequiredService<IDoencaRepository>();

                    await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
                    //Register default data
                    await Infrastructure.Identity.Seeds.DefaultGrupoUtilizador.SeedAsync(grupoPermissoesService);
                    await Infrastructure.Identity.Seeds.DefaultPermissao.SeedAsync(permissoesService);

                    //Default Seeds For Application
                    await Infrastructure.Persistence.Seeds.DefaultProjectoSeed.SeedAsync(projectoRepository);
                    await Infrastructure.Persistence.Seeds.DefaultProvinciaSeed.SeedAsync(provinciaRepository);
                    await Infrastructure.Persistence.Seeds.DefaultMunicipioSeed.SeedAsync(municipioRepository);
                    await Infrastructure.Persistence.Seeds.DefaultComunaSeed.SeedAsync(comunaRepository);
                    await Infrastructure.Persistence.Seeds.DefaultDominioSeed.SeedAsync(dominioRepository);
                    await Infrastructure.Persistence.Seeds.DefaultTipoUnidadeSeed.SeedAsync(tipoUnidadeRepository);
                    await Infrastructure.Persistence.Seeds.DefaultUnidadeSeed.SeedAsync(unidadeRepository);
                    await Infrastructure.Persistence.Seeds.DefaultEstadoManuntencaoSeed.SeedAsync(estadoManutencaoRepository);
                    await Infrastructure.Persistence.Seeds.DefaultOrigemManutencaoSeed.SeedAsync(origemManutencaoRepository);
                    await Infrastructure.Persistence.Seeds.DefaultPrestadorSeed.SeedAsync(prestadorRepository);
                    await Infrastructure.Persistence.Seeds.DefaultZonaSeed.SeedAsync(zonaRepository);

                    //await Infrastructure.Persistence.Seeds.DefaultGrupoDocumentoSeed.SeedAsync(grupoDocumentoRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultGrupoClienteSeed.SeedAsync(grupoClienteRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultGrupoSexoSeed.SeedAsync(grupoSexoRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultEstadoConsultaSeed.SeedAsync(estadoConsultaRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultDepartamentoSeed.SeedAsync(departamentoRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultEspecialidadeMedicaSeed.SeedAsync(especialidadeMedicaRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultPrioridadeSeed.SeedAsync(prioridadeRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultGrupoExame.SeedAsync(grupoExameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultTipoExameSeed.SeedAsync(tipoExameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultCategoriaExameSeed.SeedAsync(categoriaExameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultExameSeed.SeedAsync(exameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultUnidadeHospitalarSeed.SeedAsync(unidadeHospitalarRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultTipoResultadoSeed.SeedAsync(tipoResultadoRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultItemExameSeed.SeedAsync(itemExameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultResultadoItemExameSeed.SeedAsync(resultadoItemExameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultEstadoExameSeed.SeedAsync(estadoExameRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultDoencaSeed.SeedAsync(doencaRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultGrupoSintomaSeed.SeedAsync(grupoSintomaRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultSintomaSeed.SeedAsync(sintomaRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultSeguroSeed.SeedAsync(seguroRepository);

                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                  
                    webBuilder.UseStartup<Startup>();
  
                });
    }
}
