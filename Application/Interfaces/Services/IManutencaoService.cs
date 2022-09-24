/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:18
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
	public interface IManutencaoService
	{
		Task<Response<Guid>> RegisterAsync(ManutencaoDTO manutencaoDTO);
		Task<Response<Guid>> RemoveAsync(ManutencaoDTO manutencaoDTO);
		Task<Response<Guid>> UpdateAsync(ManutencaoDTO manutencaoDTO);
		Task<Response<ManutencaoDTO>> GetById(Guid id);
		Task<Response<List<ManutencaoDTO>>> GetAll();
		Task<Response<Guid>> RegisterAllAsync(ManutencaoAddDTO manutencaoDTO);
		Task<PagedResponse<List<ManutencaoRequestDTO>>> GetAllManutencaoPagination(PaginationFilter paginationFilter);
		Task<Response<List<ManutencaoRequestDTO>>> GetAllManutencao();
		Task<Response<List<ManutencaoRequestDTO>>> GetAllByUnidade(ManutencaoFilterPaginationDTO filter);
		Task<Response<List<ManutencaoRequestDTO>>> FilterManutencoes(FilterTicketsDTO filter);
		Task<Response<Guid>> RegisterAllManutencaoPreventivaAsync(ManutencaoPreventivaAddDTO manutencaoDTO);
		Task<Response<List<ManutencaoRequestDTO>>> GetAllManutencaoByUnidadeSimple(Guid IdUnidade);
		Task<PagedResponse<List<ManutencaoPreventivaRequestDTO>>> GetAllManutencaoPreventivaPagination(PaginationFilter paginationFilter);
		Task<Response<List<ManutencaoRequestDTO>>> FilterManutencoesPreventiva(FilterTicketsDTO filter);
		Task<Response<DasboardDTO>> GetDashBoard();
		Task<Response<Guid>> UpdateStateTicket(TicketUpdateEstadoDTO ticketUpdate);
		Task<Response<Guid>> AssignToUsersTicket(AssignToUsersTicketDTO assignToUsersTicket);
	}
}
