/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 14:11:12
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
		public class PrioridadeService : IPrioridadeService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IPrioridadeRepository _prioridadeRepository;


				private ILog logger;
				public PrioridadeService(IPrioridadeRepository prioridadeRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._prioridadeRepository = prioridadeRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<PrioridadeDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<PrioridadeDTO>>
						(_mapper.Map<List<PrioridadeDTO>>(await this._prioridadeRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<PrioridadeDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<PrioridadeDTO>
						(_mapper.Map<PrioridadeDTO>(await this._prioridadeRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(PrioridadeDTO prioridadeDTO)
				{
					try
					{
						var result = _mapper.Map<Prioridade>(prioridadeDTO);
						result.IdPrioridade = Guid.NewGuid();
						await _prioridadeRepository.AddAsync(result);
						return new Response<Guid>(result.IdPrioridade, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(PrioridadeDTO prioridadeDTO)
				{
					try
					{
						var result = _mapper.Map<Prioridade>(prioridadeDTO);
						await _prioridadeRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdPrioridade, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(PrioridadeDTO prioridadeDTO)
				{
					try
					{
						var result = _mapper.Map<Prioridade>(prioridadeDTO);
						await _prioridadeRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdPrioridade,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
