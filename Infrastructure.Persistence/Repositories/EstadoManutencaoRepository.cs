/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:42
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
		public class EstadoManutencaoRepository : GenericRepositoryAsync<EstadoManutencao>, IEstadoManutencaoRepository
		{
				private readonly DbSet<EstadoManutencao> _estadomanutencao;


				public EstadoManutencaoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._estadomanutencao = dbContext.Set<EstadoManutencao>();
				}


		}
}
