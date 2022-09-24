/*Gerado no Gerador de Codigo UCALL
Data: 09/05/2022 00:13:40
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
		public class ComunaService : IComunaService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IComunaRepository _comunaRepository;


				private ILog logger;
				public ComunaService(IComunaRepository comunaRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._comunaRepository = comunaRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<ComunaDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<ComunaDTO>>
						(_mapper.Map<List<ComunaDTO>>(await this._comunaRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<ComunaDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<ComunaDTO>
						(_mapper.Map<ComunaDTO>(await this._comunaRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}



				public async Task<Response<List<ComunaDTO>>> GetComunaByMunicipio(Guid idMunicpio)
				{
					try
					{
						return new Response<List<ComunaDTO>>
					   (_mapper.Map< List<ComunaDTO>> (await this._comunaRepository.GetComunaByMunicipio(idMunicpio)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(ComunaDTO comunaDTO)
				{
					try
					{
						var result = _mapper.Map<Comuna>(comunaDTO);
						result.IdComuna = Guid.NewGuid();
						await _comunaRepository.AddAsync(result);
						return new Response<Guid>(result.IdComuna, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(ComunaDTO comunaDTO)
				{
					try
					{
						var result = _mapper.Map<Comuna>(comunaDTO);
						await _comunaRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdComuna, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(ComunaDTO comunaDTO)
				{
					try
					{
						var result = _mapper.Map<Comuna>(comunaDTO);
						await _comunaRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdComuna,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
