/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:12
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
	public interface IEquipamentoService
		{
			Task<Response<Guid>> RegisterAsync(EquipamentoDTO equipamentoDTO);
			Task<Response<Guid>> RemoveAsync(EquipamentoDTO equipamentoDTO);
			Task<Response<Guid>> UpdateAsync(EquipamentoDTO equipamentoDTO);
			Task<Response<EquipamentoDTO>> GetById(Guid id);
			Task<Response<List<EquipamentoDTO>>> GetAll();
		}
}
