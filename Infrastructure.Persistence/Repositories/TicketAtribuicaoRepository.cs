/*Gerado no Gerador de Codigo UCALL
Data: 28/05/2022 08:24:37
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
		public class TicketAtribuicaoRepository : GenericRepositoryAsync<TicketAtribuicao>, ITicketAtribuicaoRepository
		{
				private readonly DbSet<TicketAtribuicao> _ticketatribuicao;


				public TicketAtribuicaoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._ticketatribuicao = dbContext.Set<TicketAtribuicao>();
				}

				public async Task<Guid> AssignToUsersTicket(List<TicketAtribuicao> atribuicoes)
				{
					await this._dbContext.TicketAtribuicao.AddRangeAsync(atribuicoes);
					await this._dbContext.SaveChangesAsync();
					return Guid.NewGuid();

				}


	}
}
