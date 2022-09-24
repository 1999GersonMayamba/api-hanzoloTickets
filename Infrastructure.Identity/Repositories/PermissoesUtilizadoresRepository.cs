/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:17
*/

using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Permissoes;
using Domain.Entities;
using Domain.Identity.Entities;
using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Identity.Repositories
{
		public class PermissoesUtilizadoresRepository : GenericRepositoryAsync<PermissaoUtilizador>, IPermissoesUtilizadoresRepository
		{
				private readonly DbSet<PermissaoUtilizador> _permissoesutilizadores;


				public PermissoesUtilizadoresRepository(IdentityContext dbContext) : base(dbContext)
				{
						this._permissoesutilizadores = dbContext.Set<PermissaoUtilizador>();
				}

				public async Task<List<PermissaoUtilizador>> GetPermissionsByIdUser(Guid id)
				{
					var UserPermissoes = await this._permissoesutilizadores.Where(e => e.IdUtilizador == id.ToString()).Select(
						p => new PermissaoUtilizador
						{

							Permissao = new Permissao
							{
								IdPermissao = p.Permissao.IdPermissao,
								Nome = p.Permissao.Nome
							}
						}).ToListAsync();

					return UserPermissoes;
				}

				public async Task<bool> DeleteAllPermissionsForUser(Guid id)
				{
					var UserPermissoes = await this._permissoesutilizadores.Where(e => e.IdUtilizador == id.ToString()).ToListAsync();
					this._permissoesutilizadores.RemoveRange(UserPermissoes);
					return await this._dbContext.SaveChangesAsync()!=0;
					
							//return UserPermissoes;
				}

				public async Task<List<PermissaoUtilizador>> RegisterRangeAsync(List<PermissaoUtilizador> permissaoUtilizador)
				{
					await this._permissoesutilizadores.AddRangeAsync(permissaoUtilizador);
					await this._dbContext.SaveChangesAsync();
					return permissaoUtilizador;
				}

	}
}
