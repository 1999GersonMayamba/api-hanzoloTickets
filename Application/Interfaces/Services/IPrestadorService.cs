/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:23
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
	public interface IPrestadorService
		{
			Task<Response<Guid>> RegisterAsync(PrestadorDTO prestadorDTO);
			Task<Response<Guid>> RemoveAsync(PrestadorDTO prestadorDTO);
			Task<Response<Guid>> UpdateAsync(PrestadorDTO prestadorDTO);
			Task<Response<PrestadorDTO>> GetById(Guid id);
			Task<Response<List<PrestadorDTO>>> GetAll();
		}
}
