/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:12
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
		public class EquipamentoService : IEquipamentoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IEquipamentoRepository _equipamentoRepository;


				private ILog logger;
				public EquipamentoService(IEquipamentoRepository equipamentoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._equipamentoRepository = equipamentoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<EquipamentoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<EquipamentoDTO>>
						(_mapper.Map<List<EquipamentoDTO>>(await this._equipamentoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<EquipamentoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<EquipamentoDTO>
						(_mapper.Map<EquipamentoDTO>(await this._equipamentoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(EquipamentoDTO equipamentoDTO)
				{
					try
					{
						var result = _mapper.Map<Equipamento>(equipamentoDTO);
						result.IdEquipamento = Guid.NewGuid();
						await _equipamentoRepository.AddAsync(result);
						return new Response<Guid>(result.IdEquipamento, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(EquipamentoDTO equipamentoDTO)
				{
					try
					{
						var result = _mapper.Map<Equipamento>(equipamentoDTO);
						await _equipamentoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdEquipamento, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(EquipamentoDTO equipamentoDTO)
				{
					try
					{
						var result = _mapper.Map<Equipamento>(equipamentoDTO);
						await _equipamentoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdEquipamento,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
