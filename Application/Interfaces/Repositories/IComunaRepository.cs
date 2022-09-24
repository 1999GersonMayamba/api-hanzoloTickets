/*Gerado no Gerador de Codigo UCALL
Data: 09/05/2022 00:13:40
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
	public interface IComunaRepository : IGenericRepositoryAsync<Comuna>
	{

		    Task<List<Comuna>> GetComunaByMunicipio(Guid IdMunicipio);
	}
}
