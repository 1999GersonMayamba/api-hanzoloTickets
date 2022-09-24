/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:47
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
		public class ProvinciaService : IProvinciaService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IProvinciaRepository _provinciaRepository;


				private ILog logger;
				public ProvinciaService(IProvinciaRepository provinciaRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._provinciaRepository = provinciaRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<ProvinciaDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<ProvinciaDTO>>
						(_mapper.Map<List<ProvinciaDTO>>(await this._provinciaRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<ProvinciaDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<ProvinciaDTO>
						(_mapper.Map<ProvinciaDTO>(await this._provinciaRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(ProvinciaDTO provinciaDTO)
				{
					try
					{
						var result = _mapper.Map<Provincia>(provinciaDTO);
						result.IdProvincia = Guid.NewGuid();
						await _provinciaRepository.AddAsync(result);
						return new Response<Guid>(result.IdProvincia, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(ProvinciaDTO provinciaDTO)
				{
					try
					{
						var result = _mapper.Map<Provincia>(provinciaDTO);
						await _provinciaRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdProvincia, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(ProvinciaDTO provinciaDTO)
				{
					try
					{
						var result = _mapper.Map<Provincia>(provinciaDTO);
						await _provinciaRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdProvincia,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
