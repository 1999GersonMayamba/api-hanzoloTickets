/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:04
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
		public class TipoDominioService : ITipoDominioService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly ITipoDominioRepository _tipodominioRepository;


				private ILog logger;
				public TipoDominioService(ITipoDominioRepository tipodominioRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._tipodominioRepository = tipodominioRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<TipoDominioDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<TipoDominioDTO>>
						(_mapper.Map<List<TipoDominioDTO>>(await this._tipodominioRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<TipoDominioDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<TipoDominioDTO>
						(_mapper.Map<TipoDominioDTO>(await this._tipodominioRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(TipoDominioDTO tipodominioDTO)
				{
					try
					{
						var result = _mapper.Map<TipoDominio>(tipodominioDTO);
						result.IdTipoDominio = Guid.NewGuid();
						await _tipodominioRepository.AddAsync(result);
						return new Response<Guid>(result.IdTipoDominio, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(TipoDominioDTO tipodominioDTO)
				{
					try
					{
						var result = _mapper.Map<TipoDominio>(tipodominioDTO);
						await _tipodominioRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdTipoDominio, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(TipoDominioDTO tipodominioDTO)
				{
					try
					{
						var result = _mapper.Map<TipoDominio>(tipodominioDTO);
						await _tipodominioRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdTipoDominio,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
