/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:22
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
		public class PermissoesService : IPermissoesService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IPermissoesRepository _permissoesRepository;


				private ILog logger;
				public PermissoesService(IPermissoesRepository permissoesRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._permissoesRepository = permissoesRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<PermissoesDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<PermissoesDTO>>
						(_mapper.Map<List<PermissoesDTO>>(await this._permissoesRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<PermissoesDTO>> GetById(int id)
				{
					try
					{
						 return new Response<PermissoesDTO>
						(_mapper.Map<PermissoesDTO>(await this._permissoesRepository.GetByIdAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<int>> RegisterAsync(PermissoesDTO permissoesDTO)
				{
					try
					{
						var result = _mapper.Map<Permissao>(permissoesDTO);
						var PermissaoList = await this._permissoesRepository.GetAllAsync();
						result.IdPermissao = PermissaoList.Count + 1;
						var Pemissoes = await _permissoesRepository.AddAsync(result);
						return new Response<int>(result.IdPermissao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<int>> RemoveAsync(PermissoesDTO permissoesDTO)
				{
					try
					{
						var result = _mapper.Map<Permissao>(permissoesDTO);
						await _permissoesRepository.DeleteAsync(result);
						return new Response<int>(result.IdPermissao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<int>> UpdateAsync(PermissoesDTO permissoesDTO)
				{
					try
					{
						var result = _mapper.Map<Permissao>(permissoesDTO);
						await _permissoesRepository.UpdateAsync(result);
						return new Response<int>(result.IdPermissao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
