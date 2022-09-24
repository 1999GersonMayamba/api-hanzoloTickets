/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:44:55
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
		public class AlocacaoManutencaoRepository : GenericRepositoryAsync<AlocacaoManutencao>, IAlocacaoManutencaoRepository
		{
				private readonly DbSet<AlocacaoManutencao> _alocacaomanutencao;


				public AlocacaoManutencaoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._alocacaomanutencao = dbContext.Set<AlocacaoManutencao>();
				}


		}
}
