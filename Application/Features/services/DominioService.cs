/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:44
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
		public class DominioService : IDominioService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IDominioRepository _dominioRepository;


				private ILog logger;
				public DominioService(IDominioRepository dominioRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._dominioRepository = dominioRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<DominioDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<DominioDTO>>
						(_mapper.Map<List<DominioDTO>>(await this._dominioRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<DominioDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<DominioDTO>
						(_mapper.Map<DominioDTO>(await this._dominioRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(DominioDTO dominioDTO)
				{
					try
					{
						var result = _mapper.Map<Dominio>(dominioDTO);
						result.IdDominio = Guid.NewGuid();
						await _dominioRepository.AddAsync(result);
						return new Response<Guid>(result.IdDominio, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(DominioDTO dominioDTO)
				{
					try
					{
						var result = _mapper.Map<Dominio>(dominioDTO);
						await _dominioRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdDominio, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(DominioDTO dominioDTO)
				{
					try
					{
						var result = _mapper.Map<Dominio>(dominioDTO);
						await _dominioRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdDominio,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
