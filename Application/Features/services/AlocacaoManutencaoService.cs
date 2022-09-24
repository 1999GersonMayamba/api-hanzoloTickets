/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:44:55
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
		public class AlocacaoManutencaoService : IAlocacaoManutencaoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IAlocacaoManutencaoRepository _alocacaomanutencaoRepository;


				private ILog logger;
				public AlocacaoManutencaoService(IAlocacaoManutencaoRepository alocacaomanutencaoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._alocacaomanutencaoRepository = alocacaomanutencaoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<AlocacaoManutencaoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<AlocacaoManutencaoDTO>>
						(_mapper.Map<List<AlocacaoManutencaoDTO>>(await this._alocacaomanutencaoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<AlocacaoManutencaoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<AlocacaoManutencaoDTO>
						(_mapper.Map<AlocacaoManutencaoDTO>(await this._alocacaomanutencaoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(AlocacaoManutencaoDTO alocacaomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<AlocacaoManutencao>(alocacaomanutencaoDTO);
						result.IdAlocacaoManutencao = Guid.NewGuid();
						await _alocacaomanutencaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdAlocacaoManutencao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(AlocacaoManutencaoDTO alocacaomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<AlocacaoManutencao>(alocacaomanutencaoDTO);
						await _alocacaomanutencaoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdAlocacaoManutencao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(AlocacaoManutencaoDTO alocacaomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<AlocacaoManutencao>(alocacaomanutencaoDTO);
						await _alocacaomanutencaoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdAlocacaoManutencao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
