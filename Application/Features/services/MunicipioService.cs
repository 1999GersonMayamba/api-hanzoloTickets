/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:51
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
		public class MunicipioService : IMunicipioService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IMunicipioRepository _municipioRepository;


				private ILog logger;
				public MunicipioService(IMunicipioRepository municipioRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._municipioRepository = municipioRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<MunicipioDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<MunicipioDTO>>
						(_mapper.Map<List<MunicipioDTO>>(await this._municipioRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<List<MunicipioDTO>>> GetAllByIdProvincia(Guid IdProvincia)
				{
					try
					{
						return new Response<List<MunicipioDTO>>
					   (_mapper.Map<List<MunicipioDTO>>(await this._municipioRepository.GetMunicipioByIdProvincia(IdProvincia)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<MunicipioDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<MunicipioDTO>
						(_mapper.Map<MunicipioDTO>(await this._municipioRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(MunicipioDTO municipioDTO)
				{
					try
					{
						var result = _mapper.Map<Municipio>(municipioDTO);
						result.IdMunicipio = Guid.NewGuid();
						await _municipioRepository.AddAsync(result);
						return new Response<Guid>(result.IdMunicipio, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(MunicipioDTO municipioDTO)
				{
					try
					{
						var result = _mapper.Map<Municipio>(municipioDTO);
						await _municipioRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdMunicipio, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(MunicipioDTO municipioDTO)
				{
					try
					{
						var result = _mapper.Map<Municipio>(municipioDTO);
						await _municipioRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdMunicipio,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
