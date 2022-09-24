/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:22
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
	public interface IProjectoManutencaoService
		{
			Task<Response<Guid>> RegisterAsync(ProjectoManutencaoDTO projectomanutencaoDTO);
			Task<Response<Guid>> RemoveAsync(ProjectoManutencaoDTO projectomanutencaoDTO);
			Task<Response<Guid>> UpdateAsync(ProjectoManutencaoDTO projectomanutencaoDTO);
			Task<Response<ProjectoManutencaoDTO>> GetById(Guid id);
			Task<Response<List<ProjectoManutencaoDTO>>> GetAll();
		}
}
