/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:42
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
	public interface IEstadoManutencaoService
		{
			Task<Response<Guid>> RegisterAsync(EstadoManutencaoDTO estadomanutencaoDTO);
			Task<Response<Guid>> RemoveAsync(EstadoManutencaoDTO estadomanutencaoDTO);
			Task<Response<Guid>> UpdateAsync(EstadoManutencaoDTO estadomanutencaoDTO);
			Task<Response<EstadoManutencaoDTO>> GetById(Guid id);
			Task<Response<List<EstadoManutencaoDTO>>> GetAll();
		}
}
