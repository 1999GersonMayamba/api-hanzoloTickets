/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:54
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
		public class DepartamentoService : IDepartamentoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IDepartamentoRepository _departamentoRepository;


				private ILog logger;
				public DepartamentoService(IDepartamentoRepository departamentoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._departamentoRepository = departamentoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<DepartamentoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<DepartamentoDTO>>
						(_mapper.Map<List<DepartamentoDTO>>(await this._departamentoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<DepartamentoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<DepartamentoDTO>
						(_mapper.Map<DepartamentoDTO>(await this._departamentoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(DepartamentoDTO departamentoDTO)
				{
					try
					{
						var result = _mapper.Map<Departamento>(departamentoDTO);
						result.IdDepartamento = Guid.NewGuid();
						await _departamentoRepository.AddAsync(result);
						return new Response<Guid>(result.IdDepartamento, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(DepartamentoDTO departamentoDTO)
				{
					try
					{
						var result = _mapper.Map<Departamento>(departamentoDTO);
						await _departamentoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdDepartamento, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(DepartamentoDTO departamentoDTO)
				{
					try
					{
						var result = _mapper.Map<Departamento>(departamentoDTO);
						await _departamentoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdDepartamento,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
