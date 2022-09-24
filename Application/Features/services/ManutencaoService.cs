/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:18
*/

using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.NLog;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Features.services
{
		public class ManutencaoService : IManutencaoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IManutencaoRepository _manutencaoRepository;
		        private readonly IProjectoManutencaoRepository _projectoManutencaoRepository;
		        private readonly IAlocacaoManutencaoRepository _alocacaoManutencaoRepository;
		        private readonly IProjectoRepository _projectoRepository;
				private readonly ITicketAtribuicaoRepository _ticketAtribuicaoRepository;
				private ILog logger;


				public ManutencaoService(IManutencaoRepository manutencaoRepository, IMapper mapper, ILog logger, IFileService fileService, 
					IProjectoManutencaoRepository projectoManutencaoRepository, 
					IAlocacaoManutencaoRepository alocacaoManutencaoRepository, IProjectoRepository projectoRepository, ITicketAtribuicaoRepository ticketAtribuicaoRepository)
				{
						_mapper = mapper;
						this._manutencaoRepository = manutencaoRepository;
						this.logger = logger;
						this._fileService = fileService;
			            this._alocacaoManutencaoRepository = alocacaoManutencaoRepository;
						this._projectoManutencaoRepository = projectoManutencaoRepository;
						this._projectoRepository = projectoRepository;
						this._ticketAtribuicaoRepository = ticketAtribuicaoRepository;
				}


				public async Task<Response<List<ManutencaoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<ManutencaoDTO>>
						(_mapper.Map<List<ManutencaoDTO>>(await this._manutencaoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<DasboardDTO>> GetDashBoard()
				{
					try
					{
						return new Response<DasboardDTO>
					   (await this._manutencaoRepository.GetDashBoard());
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}
				public async Task<Response<List<ManutencaoRequestDTO>>> GetAllManutencaoByUnidadeSimple(Guid IdUnidade)
				{
					try
					{
						return new Response<List<ManutencaoRequestDTO>>
					   (await this._manutencaoRepository.GetAllManutencaoByUnidadeSimple(IdUnidade));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<ManutencaoRequestDTO>>> GetAllManutencao()
				{
					try
					{
						return new Response<List<ManutencaoRequestDTO>>
					   (await this._manutencaoRepository.GetAllManutensao());
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<PagedResponse<List<ManutencaoRequestDTO>>> GetAllManutencaoPagination(PaginationFilter paginationFilter)
				{
					try
					{
						return await this._manutencaoRepository.GetAllManutensaoPagination(paginationFilter);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<PagedResponse<List<ManutencaoPreventivaRequestDTO>>> GetAllManutencaoPreventivaPagination(PaginationFilter paginationFilter)
				{
					try
					{
						return await this._manutencaoRepository.GetAllManutencaoPreventivaPagination(paginationFilter);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<ManutencaoRequestDTO>>> GetAllByUnidade(ManutencaoFilterPaginationDTO filter)
				{
					try
					{
						return 
						(await this._manutencaoRepository.GetAllManutencaoByUnidade(filter));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<ManutencaoRequestDTO>>> FilterManutencoes(FilterTicketsDTO filter)
				{
					try
					{
						return
						(await this._manutencaoRepository.FilterManutencoes(filter));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<ManutencaoRequestDTO>>> FilterManutencoesPreventiva(FilterTicketsDTO filter)
				{
					try
					{
						return
						(await this._manutencaoRepository.FilterManutencoesPreventiva(filter));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<ManutencaoDTO>> GetById(Guid id)
				{
					try
					{
							return new Response<ManutencaoDTO>
						(_mapper.Map<ManutencaoDTO>(await this._manutencaoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(ManutencaoDTO manutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<Manutencao>(manutencaoDTO);
						result.IdManutencao = Guid.NewGuid();
			        	result.DataRegisto = DateTime.Now;
						result.IdEstadoManutencao = Guid.Parse("61599B43-498C-4404-BC6E-902956CD54D7");
						var total = await _manutencaoRepository.GetTotalManutencoes();
						var sum = 0000 + total;
						result.CodManutencao = sum.ToString("D4");
						result.IdOrigemManutencao = !manutencaoDTO.IdOrigemManutencao.HasValue ? Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6") : manutencaoDTO.IdOrigemManutencao;
						result.IdPrestador = !manutencaoDTO.IdPrestador.HasValue ? null : Guid.Parse("008A90EA-E574-4BA8-BADF-E74284042563");
				       
				        await _manutencaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdManutencao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<Guid>> RegisterAllAsync(ManutencaoAddDTO manutencaoDTO)
				{
					/*try
					{*/
						var result = _mapper.Map<Manutencao>(manutencaoDTO);
						result.IdManutencao = Guid.NewGuid();
						result.DataRegisto = DateTime.Now;
						result.IdEstadoManutencao = Guid.Parse("61599B43-498C-4404-BC6E-902956CD54D7");
						var total = await _manutencaoRepository.GetTotalManutencoes();
						var sum = 0000 + total;
				        result.CodManutencao = sum.ToString("D4");
						result.IdOrigemManutencao = !manutencaoDTO.IdOrigemManutencao.HasValue  ? Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6") : manutencaoDTO.IdOrigemManutencao;
						result.IdPrestador = !manutencaoDTO.IdPrestador.HasValue ? null : Guid.Parse("008A90EA-E574-4BA8-BADF-E74284042563"); 
                       
						await _manutencaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdManutencao, Constantes.Constantes.RegistoSalvo);
					/*}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}*/
				}


				public async Task<Response<Guid>> RegisterAllManutencaoPreventivaAsync(ManutencaoPreventivaAddDTO manutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<Manutencao>(manutencaoDTO);
						result.IdManutencao = Guid.NewGuid();
						result.DataRegisto = DateTime.Now;
						result.IdEstadoManutencao = Guid.Parse("60D7E6B7-63AF-4885-FB0A-08DA3059B75E");
						var total = await _manutencaoRepository.GetTotalMantencoesPreventiva();
						var sum = 0000 + total;
						result.CodManutencao = sum.ToString("D4");
						result.ProjectoManutencao = null;
						result.AlocacaoManutencao = null;
						result.IdOrigemManutencao = !manutencaoDTO.IdOrigemManutencao.HasValue ? Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C") : manutencaoDTO.IdOrigemManutencao;
						result.IdPrestador = !manutencaoDTO.IdPrestador.HasValue ? null : Guid.Parse("008A90EA-E574-4BA8-BADF-E74284042563");

						await _manutencaoRepository.AddAsync(result);


				        if(manutencaoDTO.ProjectoManutencao != null)
						{

								foreach(var x in manutencaoDTO.ProjectoManutencao)
								{
									var idProjecto = await _projectoRepository.GetProjectoByCod(x.Cod);
									var projectoManutencao = new ProjectoManutencao
									{
										IdProjectoManutencao = Guid.NewGuid(),
										IdManutencao = result.IdManutencao,
										IdProjecto = idProjecto.IdProjecto
									};
						               await _projectoManutencaoRepository.AddAsync(projectoManutencao);
								}

						}


						if (manutencaoDTO.AlocacaoManutencao != null)
						{

							foreach (var x in manutencaoDTO.AlocacaoManutencao)
							{
								var projectoManutencao = new AlocacaoManutencao
								{
									IdAlocacaoManutencao = Guid.NewGuid(),
									IdManutencao = result.IdManutencao,
									DataRegisto = DateTime.Now,
									DataManutencao = DateTime.Now,
									IdUser = x.Id
								};

								await _alocacaoManutencaoRepository.AddAsync(projectoManutencao);
							}

						}


						return new Response<Guid>(result.IdManutencao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(ManutencaoDTO manutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<Manutencao>(manutencaoDTO);
						await _manutencaoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdManutencao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(ManutencaoDTO manutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<Manutencao>(manutencaoDTO);
						await _manutencaoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdManutencao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateStateTicket(TicketUpdateEstadoDTO ticketUpdate)
				{
					try
					{
						await this._manutencaoRepository.UpdateStateTicket(ticketUpdate);
						return new Response<Guid>(ticketUpdate.IdTicket, Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<Guid>> AssignToUsersTicket(AssignToUsersTicketDTO assignToUsersTicket)
				{
					try
					{

						var atribuicoes = new List<TicketAtribuicao>();

						foreach(var user in assignToUsersTicket.Users)
						{
							var ticket = new TicketAtribuicao
							{
								IdTicket = assignToUsersTicket.IdTicket,
								IdUser = user,
								IdTicketAtribuicao = Guid.NewGuid()
							};

							atribuicoes.Add(ticket);
						}

						await this._ticketAtribuicaoRepository.AssignToUsersTicket(atribuicoes);
						return new Response<Guid>(Guid.NewGuid(), Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

		}


}
