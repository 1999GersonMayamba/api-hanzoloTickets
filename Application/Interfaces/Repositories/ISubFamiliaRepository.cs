/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:07
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
	public interface ISubFamiliaRepository : IGenericRepositoryAsync<SubFamilia>
	{

		    Task<List<SubFamilia>> GetAllSubFamiliaByIdFamilia(Guid IdFamilia);

	}
}
