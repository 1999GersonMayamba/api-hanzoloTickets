/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:17
*/

using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity.Entities;

namespace Application.Interfaces.Repositories.Permissoes
{
		public interface IPermissoesUtilizadoresRepository : IGenericRepositoryAsync<PermissaoUtilizador>
		{

			Task<List<PermissaoUtilizador>> GetPermissionsByIdUser(Guid id);
			Task<bool> DeleteAllPermissionsForUser(Guid id);

			Task<List<PermissaoUtilizador>> RegisterRangeAsync(List<PermissaoUtilizador> permissaoUtilizador);


		}
}
