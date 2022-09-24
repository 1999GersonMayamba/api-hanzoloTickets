/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:59
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
	public interface IEspecialidadeMedicaService
		{
			Task<Response<Guid>> RegisterAsync(EspecialidadeMedicaDTO especialidademedicaDTO);
			Task<Response<Guid>> RemoveAsync(EspecialidadeMedicaDTO especialidademedicaDTO);
			Task<Response<Guid>> UpdateAsync(EspecialidadeMedicaDTO especialidademedicaDTO);
			Task<Response<EspecialidadeMedicaDTO>> GetById(Guid id);
			Task<Response<List<EspecialidadeMedicaDTO>>> GetAll();
		    Task<Response<List<EspecialidadeMedicaDTO>>> GetAllEspecialidadeByDepartamento(Guid IdDepartamento);
		    Task<Response<List<EspecialidadeMedicaDTO>>> GetAllEspecialidadeByDepartamentoAndIdUnidade(Guid IdDepartamento, Guid IdUnidade);
		}
}
