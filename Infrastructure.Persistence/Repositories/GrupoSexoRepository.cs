/*Gerado no Gerador de Codigo UCALL
Data: 19/03/2022 13:19:40
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
		public class GrupoSexoRepository : GenericRepositoryAsync<GrupoSexo>, IGrupoSexoRepository
		{
				private readonly DbSet<GrupoSexo> _gruposexo;


				public GrupoSexoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._gruposexo = dbContext.Set<GrupoSexo>();
				}


		}
}
