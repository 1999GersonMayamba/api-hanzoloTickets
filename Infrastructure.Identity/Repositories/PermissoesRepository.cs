/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:22
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
		public class PermissoesRepository : GenericRepositoryAsync<Permissao>, IPermissoesRepository
		{
				private readonly DbSet<Permissao> _permissoes;


				public PermissoesRepository(IdentityContext dbContext) : base(dbContext)
				{
						this._permissoes = dbContext.Set<Permissao>();
				}


		}
}
