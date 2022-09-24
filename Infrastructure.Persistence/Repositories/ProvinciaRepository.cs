/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:47
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
		public class ProvinciaRepository : GenericRepositoryAsync<Provincia>, IProvinciaRepository
		{
				private readonly DbSet<Provincia> _provincia;


				public ProvinciaRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._provincia = dbContext.Set<Provincia>();
				}


		}
}
