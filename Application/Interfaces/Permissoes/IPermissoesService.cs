/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:22
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
	public interface IPermissoesService
		{
			Task<Response<int>> RegisterAsync(PermissoesDTO permissoesDTO);
			Task<Response<int>> RemoveAsync(PermissoesDTO permissoesDTO);
			Task<Response<int>> UpdateAsync(PermissoesDTO permissoesDTO);
			Task<Response<PermissoesDTO>> GetById(int id);
			Task<Response<List<PermissoesDTO>>> GetAll();
		}
}
