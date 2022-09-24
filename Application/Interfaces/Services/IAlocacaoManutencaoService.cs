/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:44:54
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
	public interface IAlocacaoManutencaoService
		{
			Task<Response<Guid>> RegisterAsync(AlocacaoManutencaoDTO alocacaomanutencaoDTO);
			Task<Response<Guid>> RemoveAsync(AlocacaoManutencaoDTO alocacaomanutencaoDTO);
			Task<Response<Guid>> UpdateAsync(AlocacaoManutencaoDTO alocacaomanutencaoDTO);
			Task<Response<AlocacaoManutencaoDTO>> GetById(Guid id);
			Task<Response<List<AlocacaoManutencaoDTO>>> GetAll();
		}
}
