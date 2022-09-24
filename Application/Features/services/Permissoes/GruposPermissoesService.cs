/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:35
*/

using Application.DTOs;
using Application.DTOs.Permissoes;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.NLog;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Permissoes;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Permissoes;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Features.services
{
		public class GruposPermissoesService : IGruposPermissoesService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IGruposPermissoesRepository _grupospermissoesRepository;


				private ILog logger;
				public GruposPermissoesService(IGruposPermissoesRepository grupospermissoesRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._grupospermissoesRepository = grupospermissoesRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<GruposPermissoesDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<GruposPermissoesDTO>>
						(_mapper.Map<List<GruposPermissoesDTO>>(await this._grupospermissoesRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<GruposPermissoesDTO>> GetById(int id)
				{
					try
					{
						 return new Response<GruposPermissoesDTO>
						(_mapper.Map<GruposPermissoesDTO>(await this._grupospermissoesRepository.GetByIdAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<int>> RegisterAsync(GruposPermissoesDTO grupospermissoesDTO)
				{
					try
					{
						//Trazer todas as permissoes antes de inserir
						var result = _mapper.Map<GrupoPermissao>(grupospermissoesDTO);
						var GrupoPermissoes = await this._grupospermissoesRepository.GetAllAsync();
						result.IdGrupoPermissao = GrupoPermissoes.Count + 1;
						await _grupospermissoesRepository.AddAsync(result);
						return new Response<int>(result.IdGrupoPermissao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<int>> RemoveAsync(GruposPermissoesDTO grupospermissoesDTO)
				{
					try
					{
						var result = _mapper.Map<GrupoPermissao>(grupospermissoesDTO);
						await _grupospermissoesRepository.DeleteAsync(result);
						return new Response<int>(result.IdGrupoPermissao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<int>> UpdateAsync(GruposPermissoesDTO grupospermissoesDTO)
				{
					try
					{
						var result = _mapper.Map<GrupoPermissao>(grupospermissoesDTO);
						await _grupospermissoesRepository.UpdateAsync(result);
						return new Response<int>(result.IdGrupoPermissao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
