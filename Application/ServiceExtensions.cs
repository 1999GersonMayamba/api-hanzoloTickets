using Application.Behaviours;
using Application.Features.services;
using Application.Interfaces.Repositories.Permissoes;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Permissoes;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //Permissoes
            services.AddTransient<IGruposPermissoesService, GruposPermissoesService>();
            services.AddTransient<IPermissoesUtilizadoresService, PermissoesUtilizadoresService>();
            services.AddTransient<IPermissoesService, PermissoesService>();
            services.AddTransient<IGruposPermissoesService, GruposPermissoesService>();
            services.AddTransient<IDominioService, DominioService>();
            services.AddTransient<IProvinciaService, ProvinciaService>();
            services.AddTransient<IMunicipioService, MunicipioService>();
            services.AddTransient<IUnidadeService, UnidadeService>();
            services.AddTransient<IUnidadeUtilizadorService, UnidadeUtilizadorService>();
            services.AddTransient<IGrupoSexoService, GrupoSexoService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();
            services.AddTransient<IEspecialidadeMedicaService, EspecialidadeMedicaService>();
            services.AddTransient<IPrioridadeService, PrioridadeService>();
            services.AddTransient<IProjectoManutencaoService, ProjectoManutencaoService>();
            services.AddTransient<IEstadoManutencaoService, EstadoManutencaoService>();
            services.AddTransient<IFamiliaService, FamiliaService>();
            services.AddTransient<IOrigemManutencaoService, OrigemManutencaoService>();
            services.AddTransient<IProjectoService, ProjectoService>();
            services.AddTransient<ITipoDominioService, TipoDominioService>();
            services.AddTransient<ISubFamiliaService, SubFamiliaService>();
            services.AddTransient<IEquipamentoService, EquipamentoService>();
            services.AddTransient<IManutencaoService, ManutencaoService>();
            services.AddTransient<ITipoUnidadeService, TipoUnidadeService>();
            services.AddTransient<IAlocacaoManutencaoService, AlocacaoManutencaoService>();
            services.AddTransient<IPrestadorUtilizadorService, PrestadorUtilizadorService>();
            services.AddTransient<IPrestadorService, PrestadorService>();
            services.AddTransient<IZonaService, ZonaService>();
            services.AddTransient<IComunaService, ComunaService>();
            services.AddTransient<ITicketAtribuicaoService, TicketAtribuicaoService>();


        }
    }
}
