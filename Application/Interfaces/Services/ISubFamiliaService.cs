/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:07
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
	public interface ISubFamiliaService
	{
		Task<Response<Guid>> RegisterAsync(SubFamiliaDTO subfamiliaDTO);
		Task<Response<Guid>> RemoveAsync(SubFamiliaDTO subfamiliaDTO);
		Task<Response<Guid>> UpdateAsync(SubFamiliaDTO subfamiliaDTO);
		Task<Response<SubFamiliaDTO>> GetById(Guid id);
		Task<Response<List<SubFamiliaDTO>>> GetAll();
		Task<Response<List<SubFamiliaDTO>>> GetAllSubFamiliaByIdFamilia(Guid idFamilia);
	}
}
