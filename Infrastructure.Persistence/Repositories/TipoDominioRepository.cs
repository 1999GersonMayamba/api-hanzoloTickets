/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:04
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
		public class TipoDominioRepository : GenericRepositoryAsync<TipoDominio>, ITipoDominioRepository
		{
				private readonly DbSet<TipoDominio> _tipodominio;


				public TipoDominioRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._tipodominio = dbContext.Set<TipoDominio>();
				}


		}
}
