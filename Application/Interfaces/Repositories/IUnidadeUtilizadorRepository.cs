/*Gerado no Gerador de Codigo UCALL
Data: 11/03/2022 00:54:40
*/

using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces.Repositories
{
	public interface IUnidadeUtilizadorRepository : IGenericRepositoryAsync<UnidadeUtilizador>
	{
		Task<List<UnidadeUserDTO>> GetUsersByIdUser(string IdUser);
		Task<List<UnidadeUtilizador>> GetUnidadesByIdUser(Guid IdUnidade);
		Task<List<EspecialistasRequestDTO>> GetAllUserByEspecidade(Guid IdUnidade, Guid IdEspecialidade);
	}
}
