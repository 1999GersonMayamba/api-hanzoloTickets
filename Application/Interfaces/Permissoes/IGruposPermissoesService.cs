/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:35
*/

using System;
using Application.DTOs;
using Application.Wrappers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Permissoes;

namespace Application.Interfaces.Services.Permissoes
{
	public interface IGruposPermissoesService
		{
			Task<Response<int>> RegisterAsync(GruposPermissoesDTO grupospermissoesDTO);
			Task<Response<int>> RemoveAsync(GruposPermissoesDTO grupospermissoesDTO);
			Task<Response<int>> UpdateAsync(GruposPermissoesDTO grupospermissoesDTO);
			Task<Response<GruposPermissoesDTO>> GetById(int id);
			Task<Response<List<GruposPermissoesDTO>>> GetAll();
		}
}
