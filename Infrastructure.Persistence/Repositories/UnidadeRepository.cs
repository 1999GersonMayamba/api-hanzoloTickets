/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:53
*/

using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Wrappers;
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
		public class UnidadeRepository : GenericRepositoryAsync<Unidade>, IUnidadeRepository
		{
				private readonly DbSet<Unidade> _unidade;


				public UnidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._unidade = dbContext.Set<Unidade>();
				}


				public async Task<List<UnidadeRequestDTO>> GetAllUnidadesByDominio(Guid idDominio)
				{
						var unidades = await this._dbContext.Unidade.Include(x => x.Dominio)
												.Where(x => x.IdDominio == idDominio)
												.Select(t => new UnidadeRequestDTO
                                                {
													IdDominio = t.IdDominio,
													IdUnidade = t.IdUnidade,
													IdComuna = t.IdComuna,
													Nome = t.Nome,
													Descricao = t.Descricao,
													Nif = t.Nif,
													Endereco = t.Endereco,
													Telefone1 = t.Telefone1,
													Telefone2 = t.Telefone2,
													CodAgencia = t.CodAgencia,
													Email1 = t.Email1,
													Email2 = t.Email2,
													Responsavel1 = t.Responsavel1,
													Responsavel2 = t.Responsavel2,
													Whatsaap1 = t.Whatsaap1,
													Whatsaap2 = t.Whatsaap2,
													Dominio = new DominioDTO
													{
														IdDominio = t.Dominio.IdDominio,
														Descricao = t.Dominio.Descricao,
													},
													Comuna = new ComunaRequestDTO
													{
														IdComuna = t.Comuna.IdComuna,
														Descricao = t.Comuna.Descricao,
														Municipio = new MunicipioRequestDTO
														{
															IdMunicipio = t.Comuna.Municipio.IdMunicipio,
															Descricao = t.Comuna.Municipio.Descricao,

															Provincia = new ProvinciaDTO
															{
																IdProvincia = t.Comuna.Municipio.IdProvincia,
																Descricao = t.Comuna.Municipio.Provincia.Descricao
															}
														}

													},
													Zona = !t.IdZona.HasValue ? null : new ZonaDTO
                                                    {
													      IdZona = t.Zona.IdZona,
														  Descricao = t.Zona.Descricao
                                                    },
													TipoUnidade = !t.IdTipoUnidade.HasValue ? null : new TipoUnidadeDTO
                                                    {
														IdTipoUnidade = t.TipoUnidade.IdTipoUnidade,
														Descricao = t.TipoUnidade.Descricao
                                                    }
                                                }).AsNoTracking().ToListAsync();
						return unidades;
				}


		         public async Task<int> GetCountUnidades()
				{
			         var total = await this._dbContext.Unidade.CountAsync();
					return total;
				}

				public async Task<List<UnidadeRequestDTO>> GetAllDominios()
				{
					var unidades = await this._dbContext.Unidade.Include(x => x.Dominio)
											.Select(t => new UnidadeRequestDTO
											{
												IdDominio = t.IdDominio,
												IdUnidade = t.IdUnidade,
												IdComuna = t.IdComuna,
												Nome = t.Nome,
												Descricao = t.Descricao,
												Nif = t.Nif,
												Endereco = t.Endereco,
												Telefone1 = t.Telefone1,
												Telefone2 = t.Telefone2,
												CodAgencia = t.CodAgencia,
												Email1 = t.Email1,
												Email2 = t.Email2,
												Responsavel1 = t.Responsavel1,
												Responsavel2 = t.Responsavel2,
												Whatsaap1 = t.Whatsaap1,
												Whatsaap2 = t.Whatsaap2,
												Dominio = new DominioDTO
												{
													IdDominio = t.Dominio.IdDominio,
													Descricao = t.Dominio.Descricao,
												},
                                                Comuna = new ComunaRequestDTO
                                                {
                                                    IdComuna = t.Comuna.IdComuna,
                                                    Descricao = t.Comuna.Descricao,
													Municipio = new MunicipioRequestDTO
                                                    {
														IdMunicipio = t.Comuna.Municipio.IdMunicipio,
														Descricao = t.Comuna.Municipio.Descricao,

														Provincia = new ProvinciaDTO
														{
															IdProvincia = t.Comuna.Municipio.IdProvincia,
															Descricao = t.Comuna.Municipio.Provincia.Descricao
														}
													}

                                                },
                                                Zona = !t.IdZona.HasValue ? null : new ZonaDTO
												{
													IdZona = t.Zona.IdZona,
													Descricao = t.Zona.Descricao
												},
												TipoUnidade = !t.IdTipoUnidade.HasValue ? null : new TipoUnidadeDTO
												{
													IdTipoUnidade = t.TipoUnidade.IdTipoUnidade,
													Descricao = t.TipoUnidade.Descricao
												}
											}).AsNoTracking().ToListAsync();
					return unidades;
				}


				public async Task<PagedResponse<List<UnidadeRequestDTO>>> GetAllUnidadePagination(PaginationFilter paginationFilter)
				{

					var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

					var unidades = await this._dbContext.Unidade
												.OrderByDescending(x => x.CodAgencia)
												.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
												.Take(validFilter.PageSize)
												.Select(t => new UnidadeRequestDTO
												{
													IdDominio = t.IdDominio,
													IdUnidade = t.IdUnidade,
													IdComuna = t.IdComuna,
													Nome = t.Nome,
													Descricao = t.Descricao,
													Nif = t.Nif,
													Endereco = t.Endereco,
													Telefone1 = t.Telefone1,
													Telefone11 = t.Telefone11,
													Telefone2 = t.Telefone2,
													Telefone22 = t.Telefone22,
													CodAgencia = t.CodAgencia,
													Email1 = t.Email1,
													Email2 = t.Email2,
													Responsavel1 = t.Responsavel1,
													Responsavel2 = t.Responsavel2,
													Whatsaap1 = t.Whatsaap1,
													Whatsaap2 = t.Whatsaap2,
													Dominio = new DominioDTO
													{
														IdDominio = t.Dominio.IdDominio,
														Descricao = t.Dominio.Descricao,
													},
													Comuna = new ComunaRequestDTO
													{
														IdComuna = t.Comuna.IdComuna,
														Descricao = t.Comuna.Descricao,
														Municipio = new MunicipioRequestDTO
														{
															IdMunicipio = t.Comuna.Municipio.IdMunicipio,
															Descricao = t.Comuna.Municipio.Descricao,

															Provincia = new ProvinciaDTO
															{
																IdProvincia = t.Comuna.Municipio.IdProvincia,
																Descricao = t.Comuna.Municipio.Provincia.Descricao
															}
														}

													},
													Zona = !t.IdZona.HasValue ? null : new ZonaDTO
													{
														IdZona = t.Zona.IdZona,
														Descricao = t.Zona.Descricao
													},
													TipoUnidade = !t.IdTipoUnidade.HasValue ? null : new TipoUnidadeDTO
													{
														IdTipoUnidade = t.TipoUnidade.IdTipoUnidade,
														Descricao = t.TipoUnidade.Descricao
													}

												}).AsNoTracking().ToListAsync();



					var calIntermediate = decimal.Divide(this._dbContext.Unidade.Count(), validFilter.PageSize);
					var aroudn = (int)(decimal.Round(calIntermediate));
					var totalPage = aroudn;
					var totalItems = this._dbContext.Unidade.Count();


					//	return manutensoes;

					return new PagedResponse<List<UnidadeRequestDTO>>(unidades, validFilter.PageNumber, validFilter.PageSize, totalPage, totalItems, unidades.Count);
				}

		}
}
