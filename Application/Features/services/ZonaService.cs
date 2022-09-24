/*Gerado no Gerador de Codigo UCALL
Data: 10/04/2022 01:20:32
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
		public class ZonaService : IZonaService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IZonaRepository _zonaRepository;


				private ILog logger;
				public ZonaService(IZonaRepository zonaRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._zonaRepository = zonaRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<ZonaDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<ZonaDTO>>
						(_mapper.Map<List<ZonaDTO>>(await this._zonaRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<ZonaDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<ZonaDTO>
						(_mapper.Map<ZonaDTO>(await this._zonaRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(ZonaDTO zonaDTO)
				{
					try
					{
						var result = _mapper.Map<Zona>(zonaDTO);
						result.IdZona = Guid.NewGuid();
						await _zonaRepository.AddAsync(result);
						return new Response<Guid>(result.IdZona, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(ZonaDTO zonaDTO)
				{
					try
					{
						var result = _mapper.Map<Zona>(zonaDTO);
						await _zonaRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdZona, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(ZonaDTO zonaDTO)
				{
					try
					{
						var result = _mapper.Map<Zona>(zonaDTO);
						await _zonaRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdZona,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
