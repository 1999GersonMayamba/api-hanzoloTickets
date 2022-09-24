/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 11:37:40
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
	public interface ITipoUnidadeService
		{
			Task<Response<Guid>> RegisterAsync(TipoUnidadeDTO tipounidadeDTO);
			Task<Response<Guid>> RemoveAsync(TipoUnidadeDTO tipounidadeDTO);
			Task<Response<Guid>> UpdateAsync(TipoUnidadeDTO tipounidadeDTO);
			Task<Response<TipoUnidadeDTO>> GetById(Guid id);
			Task<Response<List<TipoUnidadeDTO>>> GetAll();
		}
}
