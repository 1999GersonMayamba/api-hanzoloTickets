/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:18
*/

using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Wrappers;

namespace Application.Interfaces.Repositories
{
	public interface IManutencaoRepository : IGenericRepositoryAsync<Manutencao>
	{

		Task<PagedResponse<List<ManutencaoRequestDTO>>> GetAllManutencaoByUnidade(ManutencaoFilterPaginationDTO filter);
		Task<List<ManutencaoRequestDTO>> GetAllManutensao();
	    Task<PagedResponse<List<ManutencaoRequestDTO>>> GetAllManutensaoPagination(PaginationFilter paginationFilter);
		Task<int> GetTotalManutencoes();
		Task<int> GetTotalMantencoesPreventiva();
		Task<PagedResponse<List<ManutencaoRequestDTO>>> FilterManutencoes(FilterTicketsDTO filtros);
		Task<PagedResponse<List<ManutencaoPreventivaRequestDTO>>> GetAllManutencaoPreventivaPagination(PaginationFilter paginationFilter);
		Task<List<ManutencaoRequestDTO>> GetAllManutencaoByUnidadeSimple(Guid IdUnidade);
		Task<PagedResponse<List<ManutencaoRequestDTO>>> FilterManutencoesPreventiva(FilterTicketsDTO filtros);
		Task<DasboardDTO> GetDashBoard();
		Task<Guid> UpdateStateTicket(TicketUpdateEstadoDTO ticketUpdate);

	}
}
