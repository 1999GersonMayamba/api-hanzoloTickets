/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:51
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
	public interface IMunicipioRepository : IGenericRepositoryAsync<Municipio>
	{
		    Task<List<Municipio>> GetMunicipioByIdProvincia(Guid IdProvincia);
	}
}
