/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:59
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
		public class EspecialidadeMedicaService : IEspecialidadeMedicaService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IEspecialidadeMedicaRepository _especialidademedicaRepository;


				private ILog logger;
				public EspecialidadeMedicaService(IEspecialidadeMedicaRepository especialidademedicaRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._especialidademedicaRepository = especialidademedicaRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<EspecialidadeMedicaDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<EspecialidadeMedicaDTO>>
						(_mapper.Map<List<EspecialidadeMedicaDTO>>(await this._especialidademedicaRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<EspecialidadeMedicaDTO>>> GetAllEspecialidadeByDepartamento(Guid IdDepartamento)
				{
					try
					{
						return new Response<List<EspecialidadeMedicaDTO>>
					   (_mapper.Map<List<EspecialidadeMedicaDTO>>(await this._especialidademedicaRepository.GetAllByIdDepartamento(IdDepartamento)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<EspecialidadeMedicaDTO>>> GetAllEspecialidadeByDepartamentoAndIdUnidade(Guid IdDepartamento, Guid IdUnidade)
				{
					try
					{
						return new Response<List<EspecialidadeMedicaDTO>>
					   (_mapper.Map<List<EspecialidadeMedicaDTO>>(await this._especialidademedicaRepository.GetAllByIdDepartamentoAndIdUnidade(IdDepartamento, IdUnidade)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<EspecialidadeMedicaDTO>> GetById(Guid id)
				{
					try
					{
							return new Response<EspecialidadeMedicaDTO>
						(_mapper.Map<EspecialidadeMedicaDTO>(await this._especialidademedicaRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(EspecialidadeMedicaDTO especialidademedicaDTO)
				{
					try
					{
						var result = _mapper.Map<EspecialidadeMedica>(especialidademedicaDTO);
						result.IdEspecialidadeMedica = Guid.NewGuid();
						await _especialidademedicaRepository.AddAsync(result);
						return new Response<Guid>(result.IdEspecialidadeMedica, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(EspecialidadeMedicaDTO especialidademedicaDTO)
				{
					try
					{
						var result = _mapper.Map<EspecialidadeMedica>(especialidademedicaDTO);
						await _especialidademedicaRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdEspecialidadeMedica, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(EspecialidadeMedicaDTO especialidademedicaDTO)
				{
					try
					{
						var result = _mapper.Map<EspecialidadeMedica>(especialidademedicaDTO);
						await _especialidademedicaRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdEspecialidadeMedica,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
