/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:53
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
	public interface IUnidadeService
	{
		Task<Response<Guid>> RegisterAsync(UnidadeDTO unidadeDTO);
		Task<Response<Guid>> RemoveAsync(UnidadeDTO unidadeDTO);
		Task<Response<Guid>> UpdateAsync(UnidadeDTO unidadeDTO);
		Task<Response<UnidadeDTO>> GetById(Guid id);
		//Task<Response<List<UnidadeDTO>>> GetAll();
		Task<Response<List<UnidadeRequestDTO>>> GetByDominio(Guid IdDominio);
		Task<Response<List<UnidadeRequestDTO>>> GetAll();
		Task<PagedResponse<List<UnidadeRequestDTO>>> GetAllUnidadePagination(PaginationFilter paginationFilter);
	}
}
