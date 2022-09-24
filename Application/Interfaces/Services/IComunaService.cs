/*Gerado no Gerador de Codigo UCALL
Data: 09/05/2022 00:13:40
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
	public interface IComunaService
	{
		Task<Response<Guid>> RegisterAsync(ComunaDTO comunaDTO);
		Task<Response<Guid>> RemoveAsync(ComunaDTO comunaDTO);
		Task<Response<Guid>> UpdateAsync(ComunaDTO comunaDTO);
		Task<Response<ComunaDTO>> GetById(Guid id);
		Task<Response<List<ComunaDTO>>> GetAll();
		Task<Response<List<ComunaDTO>>> GetComunaByMunicipio(Guid idMunicpio);
	}
}
