/*Gerado no Gerador de Codigo UCALL
Data: 10/04/2022 01:20:32
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
		public class ZonaRepository : GenericRepositoryAsync<Zona>, IZonaRepository
		{
				private readonly DbSet<Zona> _zona;


				public ZonaRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._zona = dbContext.Set<Zona>();
				}


		}
}
