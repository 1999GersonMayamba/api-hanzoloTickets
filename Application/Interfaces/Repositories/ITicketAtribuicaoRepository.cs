/*Gerado no Gerador de Codigo UCALL
Data: 28/05/2022 08:24:36
*/

using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Interfaces.Repositories
{
	public interface ITicketAtribuicaoRepository : IGenericRepositoryAsync<TicketAtribuicao>
	{
		Task<Guid> AssignToUsersTicket(List<TicketAtribuicao> atribuicoes);
	}
}
