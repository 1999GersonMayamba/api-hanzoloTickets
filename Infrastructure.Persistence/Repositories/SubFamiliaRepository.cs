/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:08
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
		public class SubFamiliaRepository : GenericRepositoryAsync<SubFamilia>, ISubFamiliaRepository
		{
				private readonly DbSet<SubFamilia> _subfamilia;


				public SubFamiliaRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._subfamilia = dbContext.Set<SubFamilia>();
				}


				public async Task<List<SubFamilia>> GetAllSubFamiliaByIdFamilia(Guid IdFamilia)
				{
					var subFamilia = await this._dbContext.SubFamilia.Where(x => x.IdFamilia == IdFamilia).AsNoTracking().ToListAsync();
					return subFamilia;
				}


		}
}
