/*Gerado no Gerador de Codigo UCALL
Data: 11/03/2022 00:54:40
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
		public class UnidadeUtilizadorService : IUnidadeUtilizadorService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IUnidadeUtilizadorRepository _unidadeutilizadorRepository;


				private ILog logger;
				public UnidadeUtilizadorService(IUnidadeUtilizadorRepository unidadeutilizadorRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._unidadeutilizadorRepository = unidadeutilizadorRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<UnidadeUtilizadorDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<UnidadeUtilizadorDTO>>
						(_mapper.Map<List<UnidadeUtilizadorDTO>>(await this._unidadeutilizadorRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<EspecialistasRequestDTO>>> GetAllUsersByEspecialidade(Guid IdUnidade, Guid IdEspecialidade)
				{
					try
					{
						return new Response<List<EspecialistasRequestDTO>>
					   (await this._unidadeutilizadorRepository.GetAllUserByEspecidade(IdUnidade, IdEspecialidade));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<UnidadeUtilizadorDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<UnidadeUtilizadorDTO>
						(_mapper.Map<UnidadeUtilizadorDTO>(await this._unidadeutilizadorRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(UnidadeUtilizadorDTO unidadeutilizadorDTO)
				{
					try
					{
						var result = _mapper.Map<UnidadeUtilizador>(unidadeutilizadorDTO);
						result.IdUnidadeUtilizador = Guid.NewGuid();
						await _unidadeutilizadorRepository.AddAsync(result);
						return new Response<Guid>(result.IdUnidadeUtilizador, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(UnidadeUtilizadorDTO unidadeutilizadorDTO)
				{
					try
					{
						var result = _mapper.Map<UnidadeUtilizador>(unidadeutilizadorDTO);
						await _unidadeutilizadorRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdUnidadeUtilizador, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(UnidadeUtilizadorDTO unidadeutilizadorDTO)
				{
					try
					{
						var result = _mapper.Map<UnidadeUtilizador>(unidadeutilizadorDTO);
						await _unidadeutilizadorRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdUnidadeUtilizador,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
