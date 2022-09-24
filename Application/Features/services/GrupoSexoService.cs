/*Gerado no Gerador de Codigo UCALL
Data: 19/03/2022 13:19:40
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
		public class GrupoSexoService : IGrupoSexoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IGrupoSexoRepository _gruposexoRepository;


				private ILog logger;
				public GrupoSexoService(IGrupoSexoRepository gruposexoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._gruposexoRepository = gruposexoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<GrupoSexoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<GrupoSexoDTO>>
						(_mapper.Map<List<GrupoSexoDTO>>(await this._gruposexoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<GrupoSexoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<GrupoSexoDTO>
						(_mapper.Map<GrupoSexoDTO>(await this._gruposexoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(GrupoSexoDTO gruposexoDTO)
				{
					try
					{
						var result = _mapper.Map<GrupoSexo>(gruposexoDTO);
						result.IdGrupoSexo = Guid.NewGuid();
						await _gruposexoRepository.AddAsync(result);
						return new Response<Guid>(result.IdGrupoSexo, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(GrupoSexoDTO gruposexoDTO)
				{
					try
					{
						var result = _mapper.Map<GrupoSexo>(gruposexoDTO);
						await _gruposexoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdGrupoSexo, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(GrupoSexoDTO gruposexoDTO)
				{
					try
					{
						var result = _mapper.Map<GrupoSexo>(gruposexoDTO);
						await _gruposexoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdGrupoSexo,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
