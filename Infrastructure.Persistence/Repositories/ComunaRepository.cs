/*Gerado no Gerador de Codigo UCALL
Data: 09/05/2022 00:13:40
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
		public class ComunaRepository : GenericRepositoryAsync<Comuna>, IComunaRepository
		{
				private readonly DbSet<Comuna> _comuna;


				public ComunaRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._comuna = dbContext.Set<Comuna>();
				}


				public async Task<List<Comuna>> GetComunaByMunicipio(Guid IdMunicipio)
				{
					var comunas = await this._dbContext.Comuna.Where(x => x.IdMunicipio == IdMunicipio).AsNoTracking().ToListAsync();
					return comunas;

				}


		}
}
