/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:54
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
	public interface IDepartamentoService
		{
			Task<Response<Guid>> RegisterAsync(DepartamentoDTO departamentoDTO);
			Task<Response<Guid>> RemoveAsync(DepartamentoDTO departamentoDTO);
			Task<Response<Guid>> UpdateAsync(DepartamentoDTO departamentoDTO);
			Task<Response<DepartamentoDTO>> GetById(Guid id);
			Task<Response<List<DepartamentoDTO>>> GetAll();
		}
}
