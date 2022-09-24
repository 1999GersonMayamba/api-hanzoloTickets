/*Gerado no Gerador de Codigo UCALL
Data: 10/04/2022 01:20:31
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
	public interface IZonaService
		{
			Task<Response<Guid>> RegisterAsync(ZonaDTO zonaDTO);
			Task<Response<Guid>> RemoveAsync(ZonaDTO zonaDTO);
			Task<Response<Guid>> UpdateAsync(ZonaDTO zonaDTO);
			Task<Response<ZonaDTO>> GetById(Guid id);
			Task<Response<List<ZonaDTO>>> GetAll();
		}
}
