/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:12
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
		public class EquipamentoRepository : GenericRepositoryAsync<Equipamento>, IEquipamentoRepository
		{
				private readonly DbSet<Equipamento> _equipamento;


				public EquipamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._equipamento = dbContext.Set<Equipamento>();
				}


		}
}
