/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:59
*/

using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Persistence.Repositories
{
		public class EspecialidadeMedicaRepository : GenericRepositoryAsync<EspecialidadeMedica>, IEspecialidadeMedicaRepository
		{
				private readonly DbSet<EspecialidadeMedica> _especialidademedica;


				public EspecialidadeMedicaRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._especialidademedica = dbContext.Set<EspecialidadeMedica>();
				}


				public async Task<List<EspecialidadeMedica>> GetAllByIdDepartamento(Guid IdDepartamento)
				{
					var data = await this._dbContext.EspecialidadeMedica.Where(x => x.IdDepartamento == IdDepartamento).AsNoTracking().ToListAsync();
					return data;
				}

				public async Task<List<EspecialidadeMedica>> GetAllByIdDepartamentoAndIdUnidade(Guid IdDepartamento, Guid IdUnidade)
				{
					var data = await this._dbContext.EspecialidadeMedica.Where(x => x.IdDepartamento == IdDepartamento && x.IdUnidade == IdUnidade).AsNoTracking().ToListAsync();
					return data;
				}

			}
}
