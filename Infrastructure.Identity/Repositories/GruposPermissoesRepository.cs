/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:35
*/

using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Permissoes;
using Domain.Entities;
using Domain.Identity.Entities;
using Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Identity.Repositories
{
		public class GruposPermissoesRepository : GenericRepositoryAsync<GrupoPermissao>, IGruposPermissoesRepository
		{
				private readonly DbSet<GrupoPermissao> _grupospermissoes;


				public GruposPermissoesRepository(IdentityContext dbContext) : base(dbContext)
				{
						this._grupospermissoes = dbContext.Set<GrupoPermissao>();
				}

		}
}
