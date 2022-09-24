/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:44
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
		public class DominioRepository : GenericRepositoryAsync<Dominio>, IDominioRepository
		{
				private readonly DbSet<Dominio> _dominio;


				public DominioRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._dominio = dbContext.Set<Dominio>();
				}


		}
}
