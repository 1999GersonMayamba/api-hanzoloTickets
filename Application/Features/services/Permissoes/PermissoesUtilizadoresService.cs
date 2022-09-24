/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:17
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
		public class PermissoesUtilizadoresService : IPermissoesUtilizadoresService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IPermissoesUtilizadoresRepository _permissoesutilizadoresRepository;


				private ILog logger;
				public PermissoesUtilizadoresService(IPermissoesUtilizadoresRepository permissoesutilizadoresRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._permissoesutilizadoresRepository = permissoesutilizadoresRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<PermissoesUtilizadoresDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<PermissoesUtilizadoresDTO>>
						(_mapper.Map<List<PermissoesUtilizadoresDTO>>(await this._permissoesutilizadoresRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<List<PermissoesUtilizadoresDTO>> GetPermissionsByIdUser(Guid id)
				{
					try
					{
						return new List<PermissoesUtilizadoresDTO>
						(_mapper.Map<List<PermissoesUtilizadoresDTO>>(await this._permissoesutilizadoresRepository.GetPermissionsByIdUser(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<bool> DeleteAllPermissionsForUser(Guid id)
				{
					try
					{
						return await this._permissoesutilizadoresRepository.DeleteAllPermissionsForUser(id);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<PermissoesUtilizadoresDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<PermissoesUtilizadoresDTO>
						(_mapper.Map<PermissoesUtilizadoresDTO>(await this._permissoesutilizadoresRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(PermissoesUtilizadoresDTO permissoesutilizadoresDTO)
				{
					try
					{
						var result = _mapper.Map<PermissaoUtilizador>(permissoesutilizadoresDTO);
						result.IdPermissaoUtilizador = Guid.NewGuid();
						await _permissoesutilizadoresRepository.AddAsync(result);
						return new Response<Guid>(result.IdPermissaoUtilizador, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<List<PermissoesUtilizadoresDTO>>> RegisterRangeAsync(List<PermissoesUtilizadoresDTO> permissoesutilizadoresDTO, Guid Id)
				{
					try
					{
						var result = _mapper.Map<List<PermissaoUtilizador>>(permissoesutilizadoresDTO);
						//Gerar Id para os registos
						foreach (var permission in result)
						{
							permission.IdPermissaoUtilizador = Guid.NewGuid();
							permission.IdUtilizador = Id.ToString();
						}
						var PermissoesUser = await _permissoesutilizadoresRepository.RegisterRangeAsync(result);
						return new Response<List<PermissoesUtilizadoresDTO>>(permissoesutilizadoresDTO, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(PermissoesUtilizadoresDTO permissoesutilizadoresDTO)
				{
					try
					{
						var result = _mapper.Map<PermissaoUtilizador>(permissoesutilizadoresDTO);
						await _permissoesutilizadoresRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdPermissaoUtilizador, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(PermissoesUtilizadoresDTO permissoesutilizadoresDTO)
				{
					try
					{
						var result = _mapper.Map<PermissaoUtilizador>(permissoesutilizadoresDTO);
						await _permissoesutilizadoresRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdPermissaoUtilizador,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
