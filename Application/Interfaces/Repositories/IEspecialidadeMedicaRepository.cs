/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:59
*/

using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Interfaces.Repositories
{
	public interface IEspecialidadeMedicaRepository : IGenericRepositoryAsync<EspecialidadeMedica>
		{

		    Task<List<EspecialidadeMedica>> GetAllByIdDepartamento(Guid IdDepartamento);
		    Task<List<EspecialidadeMedica>> GetAllByIdDepartamentoAndIdUnidade(Guid IdDepartamento, Guid IdUnidade);
		}
}
