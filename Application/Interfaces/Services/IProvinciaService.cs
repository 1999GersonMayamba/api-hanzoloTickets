/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:47
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
	public interface IProvinciaService
		{
			Task<Response<Guid>> RegisterAsync(ProvinciaDTO provinciaDTO);
			Task<Response<Guid>> RemoveAsync(ProvinciaDTO provinciaDTO);
			Task<Response<Guid>> UpdateAsync(ProvinciaDTO provinciaDTO);
			Task<Response<ProvinciaDTO>> GetById(Guid id);
			Task<Response<List<ProvinciaDTO>>> GetAll();
		}
}
