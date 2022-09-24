/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:52
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
		public class OrigemManutencaoService : IOrigemManutencaoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IOrigemManutencaoRepository _origemmanutencaoRepository;


				private ILog logger;
				public OrigemManutencaoService(IOrigemManutencaoRepository origemmanutencaoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._origemmanutencaoRepository = origemmanutencaoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<OrigemManutencaoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<OrigemManutencaoDTO>>
						(_mapper.Map<List<OrigemManutencaoDTO>>(await this._origemmanutencaoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<OrigemManutencaoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<OrigemManutencaoDTO>
						(_mapper.Map<OrigemManutencaoDTO>(await this._origemmanutencaoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(OrigemManutencaoDTO origemmanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<OrigemManutencao>(origemmanutencaoDTO);
						result.IdOrigemManutencao = Guid.NewGuid();
						await _origemmanutencaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdOrigemManutencao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(OrigemManutencaoDTO origemmanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<OrigemManutencao>(origemmanutencaoDTO);
						await _origemmanutencaoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdOrigemManutencao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(OrigemManutencaoDTO origemmanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<OrigemManutencao>(origemmanutencaoDTO);
						await _origemmanutencaoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdOrigemManutencao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
