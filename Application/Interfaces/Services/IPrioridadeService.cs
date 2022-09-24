/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 14:11:12
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
	public interface IPrioridadeService
		{
			Task<Response<Guid>> RegisterAsync(PrioridadeDTO prioridadeDTO);
			Task<Response<Guid>> RemoveAsync(PrioridadeDTO prioridadeDTO);
			Task<Response<Guid>> UpdateAsync(PrioridadeDTO prioridadeDTO);
			Task<Response<PrioridadeDTO>> GetById(Guid id);
			Task<Response<List<PrioridadeDTO>>> GetAll();
		}
}
