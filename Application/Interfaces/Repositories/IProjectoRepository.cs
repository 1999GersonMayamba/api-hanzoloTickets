/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:57
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
	public interface IProjectoRepository : IGenericRepositoryAsync<Projecto>
	{

		    Task<Projecto> GetProjectoByCod(string cod);
	}
}
