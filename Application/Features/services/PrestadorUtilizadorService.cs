/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:16
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
		public class PrestadorUtilizadorService : IPrestadorUtilizadorService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IPrestadorUtilizadorRepository _prestadorutilizadorRepository;


				private ILog logger;
				public PrestadorUtilizadorService(IPrestadorUtilizadorRepository prestadorutilizadorRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._prestadorutilizadorRepository = prestadorutilizadorRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<PrestadorUtilizadorDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<PrestadorUtilizadorDTO>>
						(_mapper.Map<List<PrestadorUtilizadorDTO>>(await this._prestadorutilizadorRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<PrestadorUtilizadorDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<PrestadorUtilizadorDTO>
						(_mapper.Map<PrestadorUtilizadorDTO>(await this._prestadorutilizadorRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(PrestadorUtilizadorDTO prestadorutilizadorDTO)
				{
					try
					{
						var result = _mapper.Map<PrestadorUtilizador>(prestadorutilizadorDTO);
						result.IdPrestadorUtilizador = Guid.NewGuid();
						await _prestadorutilizadorRepository.AddAsync(result);
						return new Response<Guid>(result.IdPrestadorUtilizador, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(PrestadorUtilizadorDTO prestadorutilizadorDTO)
				{
					try
					{
						var result = _mapper.Map<PrestadorUtilizador>(prestadorutilizadorDTO);
						await _prestadorutilizadorRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdPrestadorUtilizador, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(PrestadorUtilizadorDTO prestadorutilizadorDTO)
				{
					try
					{
						var result = _mapper.Map<PrestadorUtilizador>(prestadorutilizadorDTO);
						await _prestadorutilizadorRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdPrestadorUtilizador,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
