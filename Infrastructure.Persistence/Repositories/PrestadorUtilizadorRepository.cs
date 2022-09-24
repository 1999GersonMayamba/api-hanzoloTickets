/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:16
*/

using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Persistence.Repositories
{
		public class PrestadorUtilizadorRepository : GenericRepositoryAsync<PrestadorUtilizador>, IPrestadorUtilizadorRepository
		{
				private readonly DbSet<PrestadorUtilizador> _prestadorutilizador;


				public PrestadorUtilizadorRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._prestadorutilizador = dbContext.Set<PrestadorUtilizador>();
				}

				public Task<List<PrestadorUtilizadorAddDTO>> GetPrestadorByIdUser(string IdUser)
				{
					var unidades = this._dbContext.PrestadorUtilizador.Include(x => x.Prestador).Where(x => x.IdUser == IdUser)
					.Select(x => new PrestadorUtilizadorAddDTO
					{
						IdPrestadorUtilizador = x.IdPrestadorUtilizador,
						IdPrestador = x.IdPrestador,
						IdUser = x.IdUser,
						Prestador = new PrestadorDTO
                        {
							IdPrestador = x.Prestador.IdPrestador,
							Descricao = x.Prestador.Descricao,
							Nome = x.Prestador.Nome
                        }

					}).AsNoTracking().ToListAsync();


					return unidades;
				}


		}
}
