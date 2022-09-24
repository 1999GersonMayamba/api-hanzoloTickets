/*Gerado no Gerador de Codigo UCALL
Data: 11/03/2022 00:54:40
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
	public interface IUnidadeUtilizadorService
		{
			Task<Response<Guid>> RegisterAsync(UnidadeUtilizadorDTO unidadeutilizadorDTO);
			Task<Response<Guid>> RemoveAsync(UnidadeUtilizadorDTO unidadeutilizadorDTO);
			Task<Response<Guid>> UpdateAsync(UnidadeUtilizadorDTO unidadeutilizadorDTO);
			Task<Response<UnidadeUtilizadorDTO>> GetById(Guid id);
			Task<Response<List<UnidadeUtilizadorDTO>>> GetAll();
		    Task<Response<List<EspecialistasRequestDTO>>> GetAllUsersByEspecialidade(Guid IdUnidade, Guid IdEspecialidade);
		}
}
