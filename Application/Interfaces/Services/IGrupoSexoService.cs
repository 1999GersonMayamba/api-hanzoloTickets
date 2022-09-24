/*Gerado no Gerador de Codigo UCALL
Data: 19/03/2022 13:19:40
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
	public interface IGrupoSexoService
		{
			Task<Response<Guid>> RegisterAsync(GrupoSexoDTO gruposexoDTO);
			Task<Response<Guid>> RemoveAsync(GrupoSexoDTO gruposexoDTO);
			Task<Response<Guid>> UpdateAsync(GrupoSexoDTO gruposexoDTO);
			Task<Response<GrupoSexoDTO>> GetById(Guid id);
			Task<Response<List<GrupoSexoDTO>>> GetAll();
		}
}
