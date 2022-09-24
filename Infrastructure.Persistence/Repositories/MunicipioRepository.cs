/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:51
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
		public class MunicipioRepository : GenericRepositoryAsync<Municipio>, IMunicipioRepository
		{
				private readonly DbSet<Municipio> _municipio;


				public MunicipioRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._municipio = dbContext.Set<Municipio>();
				}


				public async Task<List<Municipio>> GetMunicipioByIdProvincia(Guid IdProvincia)
				{
					var municipios = await this._dbContext.Municipio.Where(x => x.IdProvincia == IdProvincia).AsNoTracking().ToListAsync();
					return municipios;

				}


		}
}
