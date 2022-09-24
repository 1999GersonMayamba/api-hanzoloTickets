/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:42
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
		public class EstadoManutencaoService : IEstadoManutencaoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IEstadoManutencaoRepository _estadomanutencaoRepository;


				private ILog logger;
				public EstadoManutencaoService(IEstadoManutencaoRepository estadomanutencaoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._estadomanutencaoRepository = estadomanutencaoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<EstadoManutencaoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<EstadoManutencaoDTO>>
						(_mapper.Map<List<EstadoManutencaoDTO>>(await this._estadomanutencaoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<EstadoManutencaoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<EstadoManutencaoDTO>
						(_mapper.Map<EstadoManutencaoDTO>(await this._estadomanutencaoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(EstadoManutencaoDTO estadomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<EstadoManutencao>(estadomanutencaoDTO);
						result.IdEstadoManutencao = Guid.NewGuid();
						await _estadomanutencaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdEstadoManutencao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(EstadoManutencaoDTO estadomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<EstadoManutencao>(estadomanutencaoDTO);
						await _estadomanutencaoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdEstadoManutencao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(EstadoManutencaoDTO estadomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<EstadoManutencao>(estadomanutencaoDTO);
						await _estadomanutencaoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdEstadoManutencao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
