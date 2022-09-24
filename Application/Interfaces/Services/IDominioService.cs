/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:44
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
	public interface IDominioService
		{
			Task<Response<Guid>> RegisterAsync(DominioDTO dominioDTO);
			Task<Response<Guid>> RemoveAsync(DominioDTO dominioDTO);
			Task<Response<Guid>> UpdateAsync(DominioDTO dominioDTO);
			Task<Response<DominioDTO>> GetById(Guid id);
			Task<Response<List<DominioDTO>>> GetAll();
		}
}
