/*Gerado no Gerador de Codigo UCALL
Data: 11/03/2022 00:54:40
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
		public class UnidadeUtilizadorRepository : GenericRepositoryAsync<UnidadeUtilizador>, IUnidadeUtilizadorRepository
		{
				private readonly DbSet<UnidadeUtilizador> _unidadeutilizador;


				public UnidadeUtilizadorRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._unidadeutilizador = dbContext.Set<UnidadeUtilizador>();
				}

				public Task<List<UnidadeUserDTO>> GetUsersByIdUser(string IdUser)
				{
						var unidades = this._dbContext.UnidadeUtilizador.Include(x => x.Unidade).Where(x => x.IdUser == IdUser)
						.Select(x => new UnidadeUserDTO
						{
							IdUnidade = x.Unidade.IdUnidade,
							IdUnidadeUtilizador = x.IdUnidadeUtilizador,
							Descricao = x.Unidade.Descricao

						}).AsNoTracking().ToListAsync();


						return unidades;
				}

				public Task<List<UnidadeUtilizador>> GetUnidadesByIdUser(Guid IdUnidade)
				{
					var unidades = this._dbContext.UnidadeUtilizador.Where(x => x.IdUnidade == IdUnidade).AsNoTracking().ToListAsync();
					return unidades;
				}

				public Task<List<EspecialistasRequestDTO>> GetAllUserByEspecidade(Guid IdUnidade, Guid IdEspecialidade)
				{
					var unidades = this._dbContext.UnidadeUtilizador.Where(x => x.IdUnidade == IdUnidade && x.IdEspecialidadeMedica == IdEspecialidade)
										.Select( g => new EspecialistasRequestDTO
                                        {
											IdUser = g.IdUser,
											Nome = g.ApplicationUser.Nome

                                        }).AsNoTracking().ToListAsync();
					return unidades;
				}


			}
}
