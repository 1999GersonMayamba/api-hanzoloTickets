/*Gerado no Gerador de Codigo UCALL
Data: 28/05/2022 08:24:37
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
		public class TicketAtribuicaoService : ITicketAtribuicaoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly ITicketAtribuicaoRepository _ticketatribuicaoRepository;


				private ILog logger;
				public TicketAtribuicaoService(ITicketAtribuicaoRepository ticketatribuicaoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._ticketatribuicaoRepository = ticketatribuicaoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<TicketAtribuicaoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<TicketAtribuicaoDTO>>
						(_mapper.Map<List<TicketAtribuicaoDTO>>(await this._ticketatribuicaoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<TicketAtribuicaoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<TicketAtribuicaoDTO>
						(_mapper.Map<TicketAtribuicaoDTO>(await this._ticketatribuicaoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(TicketAtribuicaoDTO ticketatribuicaoDTO)
				{
					try
					{
						var result = _mapper.Map<TicketAtribuicao>(ticketatribuicaoDTO);
						result.IdTicketAtribuicao = Guid.NewGuid();
						await _ticketatribuicaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdTicketAtribuicao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(TicketAtribuicaoDTO ticketatribuicaoDTO)
				{
					try
					{
						var result = _mapper.Map<TicketAtribuicao>(ticketatribuicaoDTO);
						await _ticketatribuicaoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdTicketAtribuicao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(TicketAtribuicaoDTO ticketatribuicaoDTO)
				{
					try
					{
						var result = _mapper.Map<TicketAtribuicao>(ticketatribuicaoDTO);
						await _ticketatribuicaoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdTicketAtribuicao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
