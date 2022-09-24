/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:16
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
	public interface IPrestadorUtilizadorService
		{
			Task<Response<Guid>> RegisterAsync(PrestadorUtilizadorDTO prestadorutilizadorDTO);
			Task<Response<Guid>> RemoveAsync(PrestadorUtilizadorDTO prestadorutilizadorDTO);
			Task<Response<Guid>> UpdateAsync(PrestadorUtilizadorDTO prestadorutilizadorDTO);
			Task<Response<PrestadorUtilizadorDTO>> GetById(Guid id);
			Task<Response<List<PrestadorUtilizadorDTO>>> GetAll();
		}
}
