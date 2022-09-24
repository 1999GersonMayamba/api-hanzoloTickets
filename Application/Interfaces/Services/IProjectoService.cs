/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:57
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
	public interface IProjectoService
		{
			Task<Response<Guid>> RegisterAsync(ProjectoDTO projectoDTO);
			Task<Response<Guid>> RemoveAsync(ProjectoDTO projectoDTO);
			Task<Response<Guid>> UpdateAsync(ProjectoDTO projectoDTO);
			Task<Response<ProjectoDTO>> GetById(Guid id);
			Task<Response<List<ProjectoDTO>>> GetAll();
		}
}
