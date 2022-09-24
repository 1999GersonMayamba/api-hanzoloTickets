/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 14:11:12
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
		public class PrioridadeRepository : GenericRepositoryAsync<Prioridade>, IPrioridadeRepository
		{
				private readonly DbSet<Prioridade> _prioridade;


				public PrioridadeRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._prioridade = dbContext.Set<Prioridade>();
				}


		}
}
