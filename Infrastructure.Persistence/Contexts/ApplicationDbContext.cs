using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }


        public DbSet<NotaUtilizador> Notas { get; set; }
        public DbSet<Dominio> Dominio { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Comuna> Comuna { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<UnidadeUtilizador> UnidadeUtilizador { get; set; }
        public DbSet<GrupoSexo> GrupoSexo { get; set; }
        public DbSet<EspecialidadeMedica> EspecialidadeMedica { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Prioridade> Prioridade { get; set; }
        public DbSet<EstadoManutencao> EstadoManutencao { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Projecto> Projecto { get; set; }
        public DbSet<OrigemManutencao> OrigemManutencao { get; set; }
        public DbSet<ProjectoManutencao> ProjectoManutencao { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<SubFamilia> SubFamilia { get; set; }
        public DbSet<TipoDominio> TipoDominio { get; set; }
        public DbSet<TipoUnidade> TipoUnidade { get; set; }
        public DbSet<Manutencao> Manutencao { get; set; }
        public DbSet<Prestador> Prestador { get; set; }
        public DbSet<PrestadorUtilizador> PrestadorUtilizador { get; set; }
        public DbSet<AlocacaoManutencao> AlocacaoManutencao { get; set; }
        public DbSet<Zona> Zona { get; set; }
        public DbSet<TicketAtribuicao> TicketAtribuicao { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            base.OnModelCreating(builder);
        }
    }
}
