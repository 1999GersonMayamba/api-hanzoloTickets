/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:17
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
	public interface IPermissoesUtilizadoresService
	{
		Task<Response<Guid>> RegisterAsync(PermissoesUtilizadoresDTO permissoesutilizadoresDTO);
		Task<Response<Guid>> RemoveAsync(PermissoesUtilizadoresDTO permissoesutilizadoresDTO);
		Task<Response<Guid>> UpdateAsync(PermissoesUtilizadoresDTO permissoesutilizadoresDTO);
		Task<Response<PermissoesUtilizadoresDTO>> GetById(Guid id);
		Task<Response<List<PermissoesUtilizadoresDTO>>> GetAll();
		Task<List<PermissoesUtilizadoresDTO>> GetPermissionsByIdUser(Guid id);
		Task<bool> DeleteAllPermissionsForUser(Guid id);
		Task<Response<List<PermissoesUtilizadoresDTO>>> RegisterRangeAsync(List<PermissoesUtilizadoresDTO> permissoesutilizadoresDTO, Guid Id);
	}
}
