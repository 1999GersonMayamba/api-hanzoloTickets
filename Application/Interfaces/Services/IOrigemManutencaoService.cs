/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:52
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
	public interface IOrigemManutencaoService
		{
			Task<Response<Guid>> RegisterAsync(OrigemManutencaoDTO origemmanutencaoDTO);
			Task<Response<Guid>> RemoveAsync(OrigemManutencaoDTO origemmanutencaoDTO);
			Task<Response<Guid>> UpdateAsync(OrigemManutencaoDTO origemmanutencaoDTO);
			Task<Response<OrigemManutencaoDTO>> GetById(Guid id);
			Task<Response<List<OrigemManutencaoDTO>>> GetAll();
		}
}
