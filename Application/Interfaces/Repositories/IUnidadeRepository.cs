/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:53
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
	    public interface IUnidadeRepository : IGenericRepositoryAsync<Unidade>
		{
		     Task<List<UnidadeRequestDTO>> GetAllUnidadesByDominio(Guid idDominio);
		     Task<List<UnidadeRequestDTO>> GetAllDominios();
			 Task<PagedResponse<List<UnidadeRequestDTO>>> GetAllUnidadePagination(PaginationFilter paginationFilter);
		     Task<int> GetCountUnidades();
		}
}
