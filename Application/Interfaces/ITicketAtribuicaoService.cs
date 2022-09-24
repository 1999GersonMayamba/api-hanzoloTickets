/*Gerado no Gerador de Codigo UCALL
Data: 28/05/2022 08:24:37
*/

using System;
using Application.DTOs;
using Application.Wrappers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Interfaces.Services
{
	public interface ITicketAtribuicaoService
		{
			Task<Response<Guid>> RegisterAsync(TicketAtribuicaoDTO ticketatribuicaoDTO);
			Task<Response<Guid>> RemoveAsync(TicketAtribuicaoDTO ticketatribuicaoDTO);
			Task<Response<Guid>> UpdateAsync(TicketAtribuicaoDTO ticketatribuicaoDTO);
			Task<Response<TicketAtribuicaoDTO>> GetById(Guid id);
			Task<Response<List<TicketAtribuicaoDTO>>> GetAll();
		}
}
