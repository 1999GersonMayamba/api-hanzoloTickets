/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 11:37:40
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
		public class TipoUnidadeService : ITipoUnidadeService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly ITipoUnidadeRepository _tipounidadeRepository;


				private ILog logger;
				public TipoUnidadeService(ITipoUnidadeRepository tipounidadeRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._tipounidadeRepository = tipounidadeRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<TipoUnidadeDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<TipoUnidadeDTO>>
						(_mapper.Map<List<TipoUnidadeDTO>>(await this._tipounidadeRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<TipoUnidadeDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<TipoUnidadeDTO>
						(_mapper.Map<TipoUnidadeDTO>(await this._tipounidadeRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(TipoUnidadeDTO tipounidadeDTO)
				{
					try
					{
						var result = _mapper.Map<TipoUnidade>(tipounidadeDTO);
						result.IdTipoUnidade = Guid.NewGuid();
						await _tipounidadeRepository.AddAsync(result);
						return new Response<Guid>(result.IdTipoUnidade, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(TipoUnidadeDTO tipounidadeDTO)
				{
					try
					{
						var result = _mapper.Map<TipoUnidade>(tipounidadeDTO);
						await _tipounidadeRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdTipoUnidade, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(TipoUnidadeDTO tipounidadeDTO)
				{
					try
					{
						var result = _mapper.Map<TipoUnidade>(tipounidadeDTO);
						await _tipounidadeRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdTipoUnidade,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
