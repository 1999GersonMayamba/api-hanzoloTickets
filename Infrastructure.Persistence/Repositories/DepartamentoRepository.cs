/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:54
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
		public class DepartamentoRepository : GenericRepositoryAsync<Departamento>, IDepartamentoRepository
		{
				private readonly DbSet<Departamento> _departamento;


				public DepartamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._departamento = dbContext.Set<Departamento>();
				}


		}
}
