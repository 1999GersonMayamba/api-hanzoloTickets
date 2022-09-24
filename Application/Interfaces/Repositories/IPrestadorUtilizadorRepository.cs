/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:16
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
	public interface IPrestadorUtilizadorRepository : IGenericRepositoryAsync<PrestadorUtilizador>
		{
		    Task<List<PrestadorUtilizadorAddDTO>> GetPrestadorByIdUser(string IdUser);
		}
}
