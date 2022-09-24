/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:57
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
		public class ProjectoRepository : GenericRepositoryAsync<Projecto>, IProjectoRepository
		{
				private readonly DbSet<Projecto> _projecto;


				public ProjectoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._projecto = dbContext.Set<Projecto>();
				}

		         public async Task<Projecto> GetProjectoByCod(string  cod)
				 {
					var projecto = await this._dbContext.Projecto.Where(x => x.Cod == cod).FirstOrDefaultAsync();
					return projecto;
				 }


		}
}
