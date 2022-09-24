/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:47
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
	public interface IFamiliaService
		{
			Task<Response<Guid>> RegisterAsync(FamiliaDTO familiaDTO);
			Task<Response<Guid>> RemoveAsync(FamiliaDTO familiaDTO);
			Task<Response<Guid>> UpdateAsync(FamiliaDTO familiaDTO);
			Task<Response<FamiliaDTO>> GetById(Guid id);
			Task<Response<List<FamiliaDTO>>> GetAll();
		}
}
