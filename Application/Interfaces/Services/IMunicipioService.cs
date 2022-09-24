/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:51
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
	public interface IMunicipioService
		{
			Task<Response<Guid>> RegisterAsync(MunicipioDTO municipioDTO);
			Task<Response<Guid>> RemoveAsync(MunicipioDTO municipioDTO);
			Task<Response<Guid>> UpdateAsync(MunicipioDTO municipioDTO);
			Task<Response<MunicipioDTO>> GetById(Guid id);
			Task<Response<List<MunicipioDTO>>> GetAll();
		    Task<Response<List<MunicipioDTO>>> GetAllByIdProvincia(Guid IdProvincia);
		}
}
