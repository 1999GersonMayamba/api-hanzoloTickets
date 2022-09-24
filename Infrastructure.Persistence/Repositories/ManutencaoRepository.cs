/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:18
*/

using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Persistence.Repositories
{
		public class ManutencaoRepository : GenericRepositoryAsync<Manutencao>, IManutencaoRepository
		{
				private readonly DbSet<Manutencao> _manutencao;


				public ManutencaoRepository(ApplicationDbContext dbContext) : base(dbContext)
				{
						this._manutencao = dbContext.Set<Manutencao>();
				}

				public async Task<int> GetTotalManutencoes()
				{
					var cnt = await _dbContext.Manutencao.Where(c => c.IdOrigemManutencao.Value == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6")).CountAsync();
					return cnt;

				}


				public async Task<DasboardDTO> GetDashBoard()
				{
			        var totalTicket = await this.GetTotalManutencoes();
					var totalManutencoes = await this.GetTotalMantencoesPreventiva();

					var dashboard = new DasboardDTO
					{
						TotalManutencoes = totalManutencoes,
						TotalTickets = totalTicket
					};

			        return dashboard;

				}

				public async Task<int> GetTotalMantencoesPreventiva()
				{
					var cnt = await _dbContext.Manutencao.Where(c => c.IdOrigemManutencao.Value == Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C")).CountAsync();
					return cnt;

				}

				public async Task<PagedResponse<List<ManutencaoRequestDTO>>> GetAllManutencaoByUnidade(ManutencaoFilterPaginationDTO filter)
				{

					var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

					var manutensoes = await this._dbContext.Manutencao.
					Where(x => x.IdUnidade == filter.IdUnidade && x.IdOrigemManutencao.Value == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6"))
					.OrderByDescending(x => x.DataRegisto)
					.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
					.Take(validFilter.PageSize)
					.Select(
							g => new ManutencaoRequestDTO
							{

								IdManutencao = g.IdManutencao,
								IdUnidade = g.IdUnidade,
								IdEstadoManutencao = g.IdEstadoManutencao,
								IdOrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : g.IdOrigemManutencao.Value,
								DataResolucao = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value,
								DataRegisto =  g.DataRegisto,
								DataRegistoConverted = g.DataRegisto.ToString("dd/MM/yyyy"),
								DataDaOcorrenciaConverted = !g.DataDaOcorrencia.HasValue ? null : g.DataDaOcorrencia.Value.ToString("dd/MM/yyyy"),
								CodManutencao = g.CodManutencao,
								DataResolucaoConverted = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value.ToString("dd/MM/yyyy"),
								Assunto = g.Assunto,
								Descricao = g.Descricao,
								EstadoManutencao = new EstadoManutencaoDTO
                                {
									IdEstadoManutencao = g.EstadoManutencao.IdEstadoManutencao,
									Descricao = g.EstadoManutencao.Descricao
                                },
								Unidade = new UnidadeDTO
                                {
									IdUnidade = g.Unidade.IdUnidade,
									Descricao = g.Unidade.Descricao,
									Endereco = g.Unidade.Endereco
                                },
								OrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : new OrigemManutencaoDTO
                                {
									IdOrigemManutencao = g.OrigemManutencao.IdOrigemManutencao,
									Descricao = g.OrigemManutencao.Descricao
                                },
								User = new Application.DTOs.Account.UserResponseDTO
                                {
									Id = g.ApplicationUser.Id,
									Nome = g.ApplicationUser.Nome,
									FirstName = g.ApplicationUser.FirstName,
									LastName = g.ApplicationUser.LastName
                                },
								Prioridade = !g.IdPrioridade.HasValue ? null : new PrioridadeDTO
								{

									IdPrioridade = g.Prioridade.IdPrioridade,
									Descricao = g.Prioridade.Descricao
								},
								SubFamilia = !g.IdSubFamilia.HasValue ? null : new SubFamiliaRequestDTO
								{
									IdSubFamilia = g.IdSubFamilia.Value,
									Decricao = g.SubFamilia.Decricao,
									Familia = new FamiliaDTO
									{
										IdFamilia = g.SubFamilia.Familia.IdFamilia,
										Descricao = g.SubFamilia.Familia.Descricao
									}
								},
								ProjectoManutencao = g.ProjectoManutencao.Select( 
									t => new ProjectoManutencaoRequestDTO
									{ 
									    IdManutencao = t.IdManutencao,
										IdProjecto = t.IdProjecto,
										Projecto = new ProjectoDTO
                                        {
											IdProjecto = t.Projecto.IdProjecto,
											Descricao = t.Projecto.Descricao
                                        }
									
									
									}).ToList(),
								AlocacaoManutencao = g.AlocacaoManutencao.Select(
											t => new AlocacaoManutencaoRequestDTO
											{
												IdManutencao = t.IdManutencao,
												IdAlocacaoManutencao = t.IdAlocacaoManutencao,
												DataManutencao = t.DataManutencao,
												DataRegisto = t.DataRegisto,
												User = new Application.DTOs.Account.UserResponseDTO
												{
													UserName = t.ApplicationUser.UserName,
													FirstName = t.ApplicationUser.FirstName,
													LastName = t.ApplicationUser.LastName,
													Email = t.ApplicationUser.Email,
													Nome = t.ApplicationUser.Nome,
													Telefone1 = t.ApplicationUser.Telefone1,
													Telefone2 = t.ApplicationUser.Telefone2
																								
												}


											}).ToList(),
								Prestador = !g.IdPrestador.HasValue ? null : new PrestadorDTO
                                {
									IdPrestador = g.Prestador.IdPrestador,
									Descricao = g.Prestador.Descricao,
									Nome = g.Prestador.Nome
                                }
															
							}).ToListAsync();


					var calIntermediate = decimal.Divide(this._dbContext.Manutencao.Count(), validFilter.PageSize);
					var aroudn = (int)(decimal.Round(calIntermediate));
					var totalPage = aroudn;
					var totalItems = this._dbContext.Manutencao.Count();


					//	return manutensoes;

					return new PagedResponse<List<ManutencaoRequestDTO>>(manutensoes, validFilter.PageNumber, validFilter.PageSize, totalPage, totalItems, manutensoes.Count);
				}

				public async Task<List<ManutencaoRequestDTO>> GetAllManutensao()
				{
					var manutensoes = await this._dbContext.Manutencao.Select(
						g => new ManutencaoRequestDTO
						{

							IdManutencao = g.IdManutencao,
							IdUnidade = g.IdUnidade,
							IdEstadoManutencao = g.IdEstadoManutencao,
							CodManutencao = g.CodManutencao,
							IdOrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : g.IdOrigemManutencao.Value,
							DataResolucao = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value,
							DataRegisto = g.DataRegisto,
							Assunto = g.Assunto,
							Descricao = g.Descricao,
							EstadoManutencao = new EstadoManutencaoDTO
							{
								IdEstadoManutencao = g.EstadoManutencao.IdEstadoManutencao,
								Descricao = g.EstadoManutencao.Descricao
							},
							Unidade = new UnidadeDTO
							{
								IdUnidade = g.Unidade.IdUnidade,
								Descricao = g.Unidade.Descricao,
								Endereco = g.Unidade.Endereco
							},
							OrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : new OrigemManutencaoDTO
							{
								IdOrigemManutencao = g.OrigemManutencao.IdOrigemManutencao,
								Descricao = g.OrigemManutencao.Descricao
							},
							User = new Application.DTOs.Account.UserResponseDTO
							{
								Id = g.ApplicationUser.Id,
								Nome = g.ApplicationUser.Nome,
								FirstName = g.ApplicationUser.FirstName,
								LastName = g.ApplicationUser.LastName
							},
							Prioridade = !g.IdPrioridade.HasValue ? null : new PrioridadeDTO
							{

								IdPrioridade = g.Prioridade.IdPrioridade,
								Descricao = g.Prioridade.Descricao
							},
							SubFamilia = !g.IdSubFamilia.HasValue ? null : new SubFamiliaRequestDTO
							{
								IdSubFamilia = g.IdSubFamilia.Value,
								Decricao = g.SubFamilia.Decricao,
								Familia = new FamiliaDTO
								{
									IdFamilia = g.SubFamilia.Familia.IdFamilia,
									Descricao = g.SubFamilia.Familia.Descricao
								}
							},
							ProjectoManutencao = g.ProjectoManutencao.Select(
									t => new ProjectoManutencaoRequestDTO
									{
										IdManutencao = t.IdManutencao,
										IdProjecto = t.IdProjecto,
										Projecto = new ProjectoDTO
										{
											IdProjecto = t.Projecto.IdProjecto,
											Descricao = t.Projecto.Descricao,
											Cod = t.Projecto.Cod
										}


									}).ToList(),
							Prestador = !g.IdPrestador.HasValue ? null : new PrestadorDTO
							{
								IdPrestador = g.Prestador.IdPrestador,
								Descricao = g.Prestador.Descricao,
								Nome = g.Prestador.Nome
							}



						}).ToListAsync();


					return manutensoes;
				}

				public async Task<PagedResponse<List<ManutencaoRequestDTO>>> GetAllManutensaoPagination(PaginationFilter paginationFilter)
				{

					var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

					var manutensoes = await this._dbContext.Manutencao
				                                .Where(x => x.IdOrigemManutencao == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6"))
												.OrderByDescending(x => x.DataRegisto)
												.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
												.Take(validFilter.PageSize).Select(
								g => new ManutencaoRequestDTO
								{

									IdManutencao = g.IdManutencao,
									IdUnidade = g.IdUnidade,
									IdEstadoManutencao = g.IdEstadoManutencao,
									IdOrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : g.IdOrigemManutencao.Value,
									DataResolucao = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value,
									DataRegisto = g.DataRegisto,
									CodManutencao = g.CodManutencao,
									DataRegistoConverted = g.DataRegisto.ToString("dd/MM/yyyy"),
									DataResolucaoConverted = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value.ToString("dd/MM/yyyy"),
									DataDaOcorrenciaConverted = !g.DataDaOcorrencia.HasValue ? null : g.DataDaOcorrencia.Value.ToString("dd/MM/yyyy"),
									Assunto = g.Assunto,
									Descricao = g.Descricao,
									EstadoManutencao = new EstadoManutencaoDTO
									{
										IdEstadoManutencao = g.EstadoManutencao.IdEstadoManutencao,
										Descricao = g.EstadoManutencao.Descricao
									},
									Unidade = new UnidadeDTO
									{
										IdUnidade = g.Unidade.IdUnidade,
										Descricao = g.Unidade.Descricao,
										Endereco = g.Unidade.Endereco
									},
									OrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : new OrigemManutencaoDTO
									{
										IdOrigemManutencao = g.OrigemManutencao.IdOrigemManutencao,
										Descricao = g.OrigemManutencao.Descricao
									},
									User = new Application.DTOs.Account.UserResponseDTO
									{
										Id = g.ApplicationUser.Id,
										Nome = g.ApplicationUser.Nome,
										FirstName = g.ApplicationUser.FirstName,
										LastName = g.ApplicationUser.LastName
									},
									Prioridade = !g.IdPrioridade.HasValue ? null : new PrioridadeDTO
									{

										IdPrioridade = g.Prioridade.IdPrioridade,
										Descricao = g.Prioridade.Descricao
									},
									SubFamilia = !g.IdSubFamilia.HasValue ? null : new SubFamiliaRequestDTO
                                    {
										IdSubFamilia = g.IdSubFamilia.Value,
										Decricao = g.SubFamilia.Decricao,
										Familia = new FamiliaDTO
                                        {
											IdFamilia = g.SubFamilia.Familia.IdFamilia,
											Descricao = g.SubFamilia.Familia.Descricao
                                        }
                                    },
									ProjectoManutencao = g.ProjectoManutencao.Select(
											t => new ProjectoManutencaoRequestDTO
											{
												IdManutencao = t.IdManutencao,
												IdProjecto = t.IdProjecto,
												Projecto = new ProjectoDTO
												{
													IdProjecto = t.Projecto.IdProjecto,
													Descricao = t.Projecto.Descricao,
													Cod = t.Projecto.Cod
												}


											}).ToList(),
									       AlocacaoManutencao = g.AlocacaoManutencao.Select(
											t => new AlocacaoManutencaoRequestDTO
											{
												IdManutencao = t.IdManutencao,
												IdAlocacaoManutencao = t.IdAlocacaoManutencao,
												DataManutencao = t.DataManutencao,
												DataRegisto = t.DataRegisto,
												User = new Application.DTOs.Account.UserResponseDTO
												{
													UserName = t.ApplicationUser.UserName,
													FirstName = t.ApplicationUser.FirstName,
													LastName = t.ApplicationUser.LastName,
													Email = t.ApplicationUser.Email
												}


											}).ToList(),
									Prestador = !g.IdPrestador.HasValue ? null : new PrestadorDTO
									{
										IdPrestador = g.Prestador.IdPrestador,
										Descricao = g.Prestador.Descricao,
										Nome = g.Prestador.Nome
									}



								}).ToListAsync();



							var calIntermediate = decimal.Divide(this._dbContext.Manutencao.Where(x => x.IdOrigemManutencao == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6")).Count(), validFilter.PageSize);
							var aroudn = (int)(decimal.Round(calIntermediate));
							var totalPage = aroudn;
							var totalItems = this._dbContext.Manutencao.Where(x => x.IdOrigemManutencao == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6")).Count();


						//	return manutensoes;

					return new PagedResponse<List<ManutencaoRequestDTO>>(manutensoes, validFilter.PageNumber, validFilter.PageSize, totalPage, totalItems, manutensoes.Count);
				}

				public async Task<PagedResponse<List<ManutencaoRequestDTO>>> FilterManutencoes(FilterTicketsDTO filtros)
				{
					var predicate = PredicateBuilder.New<Manutencao>(true);

					if (filtros != null)
					{
						//User Id
						if (!string.IsNullOrEmpty(filtros.UserId))
						{
							predicate = predicate.And(it => it.IdUser == filtros.UserId);
						}

						//Ticket Number
						if (!string.IsNullOrEmpty(filtros.TicketNumber))
						{
							predicate = predicate.And(it => it.CodManutencao == filtros.TicketNumber);
						}

						//Estado
						if (filtros.EstadoId.HasValue)
						{
							predicate = predicate.And(it => it.IdEstadoManutencao == filtros.EstadoId.Value);
						}

						//Data Inicio
						if (filtros.MinDate.HasValue)
						{
							predicate = predicate.And(it => it.DataRegisto.Date >= filtros.MinDate.Value.Date);
						}

						//Data Fim
						if (filtros.MaxDate.HasValue)
						{
							predicate = predicate.And(it => it.DataRegisto.Date <= filtros.MaxDate.Value.Date);
						}


			        	predicate = predicate.And(it => it.IdOrigemManutencao.Value == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6"));

						var validFilter = new PaginationFilter(filtros.PageNumber, filtros.PageSize);

						var manutensoes = await this._dbContext.Manutencao
													 .Where(predicate)
													.OrderByDescending(x => x.DataRegisto)
													.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
													.Take(validFilter.PageSize).Select(
									g => new ManutencaoRequestDTO
									{

										IdManutencao = g.IdManutencao,
										IdUnidade = g.IdUnidade,
										IdEstadoManutencao = g.IdEstadoManutencao,
										IdOrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : g.IdOrigemManutencao.Value,
										DataResolucao = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value,
										DataRegisto = g.DataRegisto,
										CodManutencao = g.CodManutencao,
										DataRegistoConverted = g.DataRegisto.ToString("dd/MM/yyyy"),
										DataResolucaoConverted = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value.ToString("dd/MM/yyyy"),
										DataDaOcorrenciaConverted = !g.DataDaOcorrencia.HasValue ? null : g.DataDaOcorrencia.Value.ToString("dd/MM/yyyy"),
										Assunto = g.Assunto,
										Descricao = g.Descricao,
										EstadoManutencao = new EstadoManutencaoDTO
										{
											IdEstadoManutencao = g.EstadoManutencao.IdEstadoManutencao,
											Descricao = g.EstadoManutencao.Descricao
										},
										Unidade = new UnidadeDTO
										{
											IdUnidade = g.Unidade.IdUnidade,
											Descricao = g.Unidade.Descricao,
											Endereco = g.Unidade.Endereco
										},
										OrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : new OrigemManutencaoDTO
										{
											IdOrigemManutencao = g.OrigemManutencao.IdOrigemManutencao,
											Descricao = g.OrigemManutencao.Descricao
										},
										User = new Application.DTOs.Account.UserResponseDTO
										{
											Id = g.ApplicationUser.Id,
											Nome = g.ApplicationUser.Nome,
											FirstName = g.ApplicationUser.FirstName,
											LastName = g.ApplicationUser.LastName
										},
										Prioridade = !g.IdPrioridade.HasValue ? null : new PrioridadeDTO { 
										
										  IdPrioridade = g.Prioridade.IdPrioridade,
										  Descricao = g.Prioridade.Descricao
										},
										SubFamilia = !g.IdSubFamilia.HasValue ? null : new SubFamiliaRequestDTO
										{
											IdSubFamilia = g.IdSubFamilia.Value,
											Decricao = g.SubFamilia.Decricao,
											Familia = new FamiliaDTO
											{
												IdFamilia = g.SubFamilia.Familia.IdFamilia,
												Descricao = g.SubFamilia.Familia.Descricao
											}
										},
										ProjectoManutencao = g.ProjectoManutencao.Select(
												t => new ProjectoManutencaoRequestDTO
												{
													IdManutencao = t.IdManutencao,
													IdProjecto = t.IdProjecto,
													Projecto = new ProjectoDTO
													{
														IdProjecto = t.Projecto.IdProjecto,
														Descricao = t.Projecto.Descricao,
														Cod = t.Projecto.Cod
													}


												}).ToList(),
										AlocacaoManutencao = g.AlocacaoManutencao.Select(
												t => new AlocacaoManutencaoRequestDTO
												{
													IdManutencao = t.IdManutencao,
													IdAlocacaoManutencao = t.IdAlocacaoManutencao,
													DataManutencao = t.DataManutencao,
													DataRegisto = t.DataRegisto,
													User = new Application.DTOs.Account.UserResponseDTO
													{
														UserName = t.ApplicationUser.UserName,
														FirstName = t.ApplicationUser.FirstName,
														LastName = t.ApplicationUser.LastName,
														Email = t.ApplicationUser.Email
													}


												}).ToList(),
										Prestador = !g.IdPrestador.HasValue ? null : new PrestadorDTO
										{
											IdPrestador = g.Prestador.IdPrestador,
											Descricao = g.Prestador.Descricao,
											Nome = g.Prestador.Nome
										}



									}).ToListAsync();



						var calIntermediate = decimal.Divide(this._dbContext.Manutencao.Where(predicate).Count(), validFilter.PageSize);
						var aroudn = (int)(decimal.Round(calIntermediate));
						var totalPage = aroudn;
						var totalItems = this._dbContext.Manutencao.Where(predicate).Count();


					return new PagedResponse<List<ManutencaoRequestDTO>>(manutensoes, validFilter.PageNumber, validFilter.PageSize, totalPage, totalItems, manutensoes.Count);


				}

					var pagination = new PaginationFilter()
					{
						PageNumber = filtros.PageNumber,
						PageSize = filtros.PageSize
					};

					return await this.GetAllManutensaoPagination(pagination);

				}

				public async Task<PagedResponse<List<ManutencaoPreventivaRequestDTO>>> GetAllManutencaoPreventivaPagination(PaginationFilter paginationFilter)
				{

					var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

					var manutensoes = await this._dbContext.Manutencao
												.Where(x => x.IdOrigemManutencao == Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C"))
												.OrderByDescending(x => x.DataRegisto)
												.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
												.Take(validFilter.PageSize).Select(
								g => new ManutencaoPreventivaRequestDTO
								{

									IdManutencao = g.IdManutencao,
									IdUnidade = g.IdUnidade,
									IdEstadoManutencao = g.IdEstadoManutencao,
									IdOrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : g.IdOrigemManutencao.Value,
									DataResolucao = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value,
									DataRegisto = g.DataRegisto,
									CodManutencao = g.CodManutencao,
									DataRegistoConverted = g.DataRegisto.ToString("dd/MM/yyyy"),
									DataResolucaoConverted = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value.ToString("dd/MM/yyyy"),
									DataManutencaoConverted = !g.DataManutencao.HasValue ? null : g.DataManutencao.Value.ToString("dd/MM/yyyy"),
									DataDaOcorrenciaConverted = !g.DataDaOcorrencia.HasValue ? null : g.DataDaOcorrencia.Value.ToString("dd/MM/yyyy"),
									TicketNumber = g.TicketNumber,
									Assunto = g.Assunto,
									Descricao = g.Descricao,
									EstadoManutencao = new EstadoManutencaoDTO
									{
										IdEstadoManutencao = g.EstadoManutencao.IdEstadoManutencao,
										Descricao = g.EstadoManutencao.Descricao
									},
									Unidade = new UnidadeDTO
									{
										IdUnidade = g.Unidade.IdUnidade,
										Descricao = g.Unidade.Descricao,
										Endereco = g.Unidade.Endereco
									},
									OrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : new OrigemManutencaoDTO
									{
										IdOrigemManutencao = g.OrigemManutencao.IdOrigemManutencao,
										Descricao = g.OrigemManutencao.Descricao
									},
									User = new Application.DTOs.Account.UserResponseDTO
									{
										Id = g.ApplicationUser.Id,
										Nome = g.ApplicationUser.Nome,
										FirstName = g.ApplicationUser.FirstName,
										LastName = g.ApplicationUser.LastName
									},
									Prioridade = !g.IdPrioridade.HasValue ? null : new PrioridadeDTO
									{

										IdPrioridade = g.Prioridade.IdPrioridade,
										Descricao = g.Prioridade.Descricao
									},
									SubFamilia = !g.IdSubFamilia.HasValue ? null : new SubFamiliaRequestDTO
									{
										IdSubFamilia = g.IdSubFamilia.Value,
										Decricao = g.SubFamilia.Decricao,
										Familia = new FamiliaDTO
										{
											IdFamilia = g.SubFamilia.Familia.IdFamilia,
											Descricao = g.SubFamilia.Familia.Descricao
										}
									},
									ProjectoManutencao = g.ProjectoManutencao.Select(
											t => new ProjectoManutencaoRequestDTO
											{
												IdManutencao = t.IdManutencao,
												IdProjecto = t.IdProjecto,
												Projecto = new ProjectoDTO
												{
													IdProjecto = t.Projecto.IdProjecto,
													Descricao = t.Projecto.Descricao,
													Cod = t.Projecto.Cod
												}


											}).ToList(),
									AlocacaoManutencao = g.AlocacaoManutencao.Select(
											t => new AlocacaoManutencaoRequestDTO
											{
												IdManutencao = t.IdManutencao,
												IdAlocacaoManutencao = t.IdAlocacaoManutencao,
												DataManutencao = t.DataManutencao,
												DataRegisto = t.DataRegisto,
												User = new Application.DTOs.Account.UserResponseDTO
												{
													UserName = t.ApplicationUser.UserName,
													FirstName = t.ApplicationUser.FirstName,
													LastName = t.ApplicationUser.LastName,
													Nome = t.ApplicationUser.Nome,
													Email = t.ApplicationUser.Email
												}


											}).ToList(),
									Prestador = !g.IdPrestador.HasValue ? null : new PrestadorDTO
									{
										IdPrestador = g.Prestador.IdPrestador,
										Descricao = g.Prestador.Descricao,
										Nome = g.Prestador.Nome
									}



								}).ToListAsync();



					var calIntermediate = decimal.Divide(this._dbContext.Manutencao.Where(x => x.IdOrigemManutencao == Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C")).Count(), validFilter.PageSize);
					var aroudn = (int)(decimal.Round(calIntermediate));
					var totalPage = aroudn;
					var totalItems = this._dbContext.Manutencao.Where(x => x.IdOrigemManutencao == Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C")).Count();


					//	return manutensoes;

					return new PagedResponse<List<ManutencaoPreventivaRequestDTO>>(manutensoes, validFilter.PageNumber, validFilter.PageSize, totalPage, totalItems, manutensoes.Count);
				}

				public async Task<List<ManutencaoRequestDTO>> GetAllManutencaoByUnidadeSimple(Guid IdUnidade)
				{


					var manutensoes = await this._dbContext.Manutencao.
					Where(x =>  x.IdOrigemManutencao.Value == Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6") && x.IdUnidade == IdUnidade)
					.OrderByDescending(x => x.DataRegisto)
					.Select(
							g => new ManutencaoRequestDTO
							{

								CodManutencao = g.CodManutencao

							}).ToListAsync();

					return manutensoes;
				}

				public async Task<PagedResponse<List<ManutencaoRequestDTO>>> FilterManutencoesPreventiva(FilterTicketsDTO filtros)
				{
					var predicate = PredicateBuilder.New<Manutencao>(true);

					if (filtros != null)
					{
						//User Id
						if (!string.IsNullOrEmpty(filtros.UserId))
						{
							predicate = predicate.And(it => it.IdUser == filtros.UserId);
						}

						//Ticket Number
						if (!string.IsNullOrEmpty(filtros.TicketNumber))
						{
							predicate = predicate.And(it => it.CodManutencao == filtros.TicketNumber);
						}

						//Estado
						if (filtros.EstadoId.HasValue)
						{
							predicate = predicate.And(it => it.IdEstadoManutencao == filtros.EstadoId.Value);
						}

						//Data Inicio
						if (filtros.MinDate.HasValue)
						{
							predicate = predicate.And(it => it.DataRegisto.Date >= filtros.MinDate.Value.Date);
						}

						//Data Fim
						if (filtros.MaxDate.HasValue)
						{
							predicate = predicate.And(it => it.DataRegisto.Date <= filtros.MaxDate.Value.Date);
						}


						predicate = predicate.And(it => it.IdOrigemManutencao.Value == Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C"));

						var validFilter = new PaginationFilter(filtros.PageNumber, filtros.PageSize);

						var manutensoes = await this._dbContext.Manutencao
													 .Where(predicate)
													.OrderByDescending(x => x.DataRegisto)
													.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
													.Take(validFilter.PageSize).Select(
									g => new ManutencaoRequestDTO
									{

										IdManutencao = g.IdManutencao,
										IdUnidade = g.IdUnidade,
										IdEstadoManutencao = g.IdEstadoManutencao,
										IdOrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : g.IdOrigemManutencao.Value,
										DataResolucao = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value,
										DataRegisto = g.DataRegisto,
										CodManutencao = g.CodManutencao,
										DataRegistoConverted = g.DataRegisto.ToString("dd/MM/yyyy"),
										DataResolucaoConverted = !g.DataResolucao.HasValue ? null : g.DataResolucao.Value.ToString("dd/MM/yyyy"),
										DataDaOcorrenciaConverted = !g.DataDaOcorrencia.HasValue ? null : g.DataDaOcorrencia.Value.ToString("dd/MM/yyyy"),
										Assunto = g.Assunto,
										Descricao = g.Descricao,
										EstadoManutencao = new EstadoManutencaoDTO
										{
											IdEstadoManutencao = g.EstadoManutencao.IdEstadoManutencao,
											Descricao = g.EstadoManutencao.Descricao
										},
										Unidade = new UnidadeDTO
										{
											IdUnidade = g.Unidade.IdUnidade,
											Descricao = g.Unidade.Descricao,
											Endereco = g.Unidade.Endereco
										},
										OrigemManutencao = !g.IdOrigemManutencao.HasValue ? null : new OrigemManutencaoDTO
										{
											IdOrigemManutencao = g.OrigemManutencao.IdOrigemManutencao,
											Descricao = g.OrigemManutencao.Descricao
										},
										User = new Application.DTOs.Account.UserResponseDTO
										{
											Id = g.ApplicationUser.Id,
											Nome = g.ApplicationUser.Nome,
											FirstName = g.ApplicationUser.FirstName,
											LastName = g.ApplicationUser.LastName
										},
										Prioridade = !g.IdPrioridade.HasValue ? null : new PrioridadeDTO
										{

											IdPrioridade = g.Prioridade.IdPrioridade,
											Descricao = g.Prioridade.Descricao
										},
										SubFamilia = !g.IdSubFamilia.HasValue ? null : new SubFamiliaRequestDTO
										{
											IdSubFamilia = g.IdSubFamilia.Value,
											Decricao = g.SubFamilia.Decricao,
											Familia = new FamiliaDTO
											{
												IdFamilia = g.SubFamilia.Familia.IdFamilia,
												Descricao = g.SubFamilia.Familia.Descricao
											}
										},
										ProjectoManutencao = g.ProjectoManutencao.Select(
												t => new ProjectoManutencaoRequestDTO
												{
													IdManutencao = t.IdManutencao,
													IdProjecto = t.IdProjecto,
													Projecto = new ProjectoDTO
													{
														IdProjecto = t.Projecto.IdProjecto,
														Descricao = t.Projecto.Descricao,
														Cod = t.Projecto.Cod
													}


												}).ToList(),
										AlocacaoManutencao = g.AlocacaoManutencao.Select(
												t => new AlocacaoManutencaoRequestDTO
												{
													IdManutencao = t.IdManutencao,
													IdAlocacaoManutencao = t.IdAlocacaoManutencao,
													DataManutencao = t.DataManutencao,
													DataRegisto = t.DataRegisto,
													User = new Application.DTOs.Account.UserResponseDTO
													{
														UserName = t.ApplicationUser.UserName,
														FirstName = t.ApplicationUser.FirstName,
														LastName = t.ApplicationUser.LastName,
														Email = t.ApplicationUser.Email
													}


												}).ToList(),
										Prestador = !g.IdPrestador.HasValue ? null : new PrestadorDTO
										{
											IdPrestador = g.Prestador.IdPrestador,
											Descricao = g.Prestador.Descricao,
											Nome = g.Prestador.Nome
										}



									}).ToListAsync();



						var calIntermediate = decimal.Divide(this._dbContext.Manutencao.Where(predicate).Count(), validFilter.PageSize);
						var aroudn = (int)(decimal.Round(calIntermediate));
						var totalPage = aroudn;
						var totalItems = this._dbContext.Manutencao.Where(predicate).Count();


						return new PagedResponse<List<ManutencaoRequestDTO>>(manutensoes, validFilter.PageNumber, validFilter.PageSize, totalPage, totalItems, manutensoes.Count);


					}

					var pagination = new PaginationFilter()
					{
						PageNumber = filtros.PageNumber,
						PageSize = filtros.PageSize
					};

					return await this.GetAllManutensaoPagination(pagination);

				}

				public async Task<Guid> UpdateStateTicket(TicketUpdateEstadoDTO ticketUpdate)
				{

					var ticket = await this._dbContext.Manutencao.Where(x => x.IdManutencao == ticketUpdate.IdTicket).FirstOrDefaultAsync();
					ticket.IdEstadoManutencao = ticketUpdate.IdEstado;
					this._dbContext.Manutencao.Update(ticket);
					await this._dbContext.SaveChangesAsync();
					return ticketUpdate.IdTicket;

				}


		//public async Task<Guid> AssignToProjectoTicket(AssignToProjectoTicketDTO assignToProjectoTicket)
		//{

		//	var ticket = await this._dbContext.Manutencao.Where(x => x.IdManutencao == ticketUpdate.IdTicket).FirstOrDefaultAsync();
		//	ticket.IdEstadoManutencao = ticketUpdate.IdEstado;
		//	this._dbContext.Manutencao.Update(ticket);
		//	await this._dbContext.SaveChangesAsync();
		//	return ticketUpdate.IdTicket;

		//}


	}
}
