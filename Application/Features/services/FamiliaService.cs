/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:47
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
		public class FamiliaService : IFamiliaService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IFamiliaRepository _familiaRepository;


				private ILog logger;
				public FamiliaService(IFamiliaRepository familiaRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._familiaRepository = familiaRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<FamiliaDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<FamiliaDTO>>
						(_mapper.Map<List<FamiliaDTO>>(await this._familiaRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<FamiliaDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<FamiliaDTO>
						(_mapper.Map<FamiliaDTO>(await this._familiaRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(FamiliaDTO familiaDTO)
				{
					try
					{
						var result = _mapper.Map<Familia>(familiaDTO);
						result.IdFamilia = Guid.NewGuid();
						await _familiaRepository.AddAsync(result);
						return new Response<Guid>(result.IdFamilia, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(FamiliaDTO familiaDTO)
				{
					try
					{
						var result = _mapper.Map<Familia>(familiaDTO);
						await _familiaRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdFamilia, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(FamiliaDTO familiaDTO)
				{
					try
					{
						var result = _mapper.Map<Familia>(familiaDTO);
						await _familiaRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdFamilia,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
