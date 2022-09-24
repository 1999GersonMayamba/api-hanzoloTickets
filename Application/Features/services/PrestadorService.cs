/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:23
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
		public class PrestadorService : IPrestadorService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IPrestadorRepository _prestadorRepository;


				private ILog logger;
				public PrestadorService(IPrestadorRepository prestadorRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._prestadorRepository = prestadorRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<PrestadorDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<PrestadorDTO>>
						(_mapper.Map<List<PrestadorDTO>>(await this._prestadorRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<PrestadorDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<PrestadorDTO>
						(_mapper.Map<PrestadorDTO>(await this._prestadorRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(PrestadorDTO prestadorDTO)
				{
					try
					{
						var result = _mapper.Map<Prestador>(prestadorDTO);
						result.IdPrestador = Guid.NewGuid();
						await _prestadorRepository.AddAsync(result);
						return new Response<Guid>(result.IdPrestador, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(PrestadorDTO prestadorDTO)
				{
					try
					{
						var result = _mapper.Map<Prestador>(prestadorDTO);
						await _prestadorRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdPrestador, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(PrestadorDTO prestadorDTO)
				{
					try
					{
						var result = _mapper.Map<Prestador>(prestadorDTO);
						await _prestadorRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdPrestador,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
