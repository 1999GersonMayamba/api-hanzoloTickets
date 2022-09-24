/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 11:37:40
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
		public class TipoUnidadeRepository : GenericRepositoryAsync<TipoUnidade>, ITipoUnidadeRepository
		{
				private readonly DbSet<TipoUnidade> _tipounidade;


				public TipoUnidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._tipounidade = dbContext.Set<TipoUnidade>();
				}


		}
}
