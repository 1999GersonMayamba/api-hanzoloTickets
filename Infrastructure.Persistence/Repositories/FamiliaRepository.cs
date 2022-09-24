/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:47
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
		public class FamiliaRepository : GenericRepositoryAsync<Familia>, IFamiliaRepository
		{
				private readonly DbSet<Familia> _familia;


				public FamiliaRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._familia = dbContext.Set<Familia>();
				}


		}
}
