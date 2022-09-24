/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:03
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
	public interface ITipoDominioService
		{
			Task<Response<Guid>> RegisterAsync(TipoDominioDTO tipodominioDTO);
			Task<Response<Guid>> RemoveAsync(TipoDominioDTO tipodominioDTO);
			Task<Response<Guid>> UpdateAsync(TipoDominioDTO tipodominioDTO);
			Task<Response<TipoDominioDTO>> GetById(Guid id);
			Task<Response<List<TipoDominioDTO>>> GetAll();
		}
}
