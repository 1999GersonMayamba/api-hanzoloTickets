using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("CleanArq"));
            }
            else
            {

                 var conn = configuration.GetConnectionString("CONN");// Buscar das variaveis de ambiente
                //var conn = configuration.GetValue("CONN", configuration.GetConnectionString("CONN"));


                //#if !DEBUG
                //                            if (string.IsNullOrEmpty(conn))
                //                                throw new Exception("Connection String not loaded.");
                //#endif

                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   conn,
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); //configuration.GetConnectionString("DefaultConnection")
            }
            #region Repositories


            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            //services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<INotaUtilizadorRepository, NotaRepository>();
            services.AddTransient<IDominioRepository, DominioRepository>();
            services.AddTransient<IProvinciaRepository, ProvinciaRepository>();
            services.AddTransient<IMunicipioRepository, MunicipioRepository>();
            services.AddTransient<IUnidadeRepository, UnidadeRepository>();
            services.AddTransient<IUnidadeUtilizadorRepository, UnidadeUtilizadorRepository>();
            //services.AddTransient<IEstadoConsultaRepository, EstadoConsultaRepository>();
            //services.AddTransient<IGrupoClienteRepository, GrupoClienteRepository>();
            //services.AddTransient<IGrupoDocumentoRepository, GrupoDocumentoRepository>();
            services.AddTransient<IGrupoSexoRepository, GrupoSexoRepository>();
            //services.AddTransient<IClienteRepository, ClienteRepository>();
            //services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
            services.AddTransient<IEspecialidadeMedicaRepository, EspecialidadeMedicaRepository>();
            services.AddTransient<IPrioridadeRepository, PrioridadeRepository>();
            services.AddTransient<IProjectoManutencaoRepository, ProjectoManutencaoRepository>();
            services.AddTransient<IEstadoManutencaoRepository, EstadoManutencaoRepository>();
            services.AddTransient<IFamiliaRepository, FamiliaRepository>();
            services.AddTransient<IOrigemManutencaoRepository, OrigemManutencaoRepository>();
            services.AddTransient<IProjectoRepository, ProjectoRepository>();
            services.AddTransient<ITipoDominioRepository, TipoDominioRepository>();
            services.AddTransient<ISubFamiliaRepository, SubFamiliaRepository>();
            services.AddTransient<IEquipamentoRepository, EquipamentoRepository>();
            services.AddTransient<IManutencaoRepository, ManutencaoRepository>();
            services.AddTransient<ITipoUnidadeRepository, TipoUnidadeRepository>();
            services.AddTransient<IAlocacaoManutencaoRepository, AlocacaoManutencaoRepository>();
            services.AddTransient<IPrestadorUtilizadorRepository, PrestadorUtilizadorRepository>();
            services.AddTransient<IPrestadorRepository, PrestadorRepository>();
            services.AddTransient<IZonaRepository, ZonaRepository>();
            services.AddTransient<IComunaRepository, ComunaRepository>();
            services.AddTransient<ITicketAtribuicaoRepository, TicketAtribuicaoRepository>();
            //services.AddTransient<ITipoResultadoRepository, TipoResultadoRepository>();
            //services.AddTransient<IUnidadeHospitalarRepository, UnidadeHospitalarRepository>();
            //services.AddTransient<ITipoExameRepository, TipoExameRepository>();
            //services.AddTransient<IExameRepository, ExameRepository>();
            //services.AddTransient<IItemExameRepository, ItemExameRepository>();
            //services.AddTransient<IResultadoItemExameRepository, ResultadoItemExameRepository>();
            //services.AddTransient<ICategoriaExameRepository, CategoriaExameRepository>();
            //services.AddTransient<IGrupoExameRepository, GrupoExameRepository>();
            //services.AddTransient<IEstadoExameRepository, EstadoExameRepository>();
            //services.AddTransient<IExameConsultaRepository, ExameConsultaRepository>();
            //services.AddTransient<IExameConsultaResultadoRepository, ExameConsultaResultadoRepository>();
            //services.AddTransient<IDoencaRepository, DoencaRepository>();
            //services.AddTransient<ISintomaRepository, SintomaRepository>();
            //services.AddTransient<IGrupoSintomaRepository, GrupoSintomaRepository>();
            //services.AddTransient<ISintomaConsultaRepository, SintomaConsultaRepository>();
            //services.AddTransient<ISeguroRepository, SeguroRepository>();
            #endregion
        }
    }
}
