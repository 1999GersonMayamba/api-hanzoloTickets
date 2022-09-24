/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:08
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
		public class SubFamiliaService : ISubFamiliaService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly ISubFamiliaRepository _subfamiliaRepository;


				private ILog logger;
				public SubFamiliaService(ISubFamiliaRepository subfamiliaRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._subfamiliaRepository = subfamiliaRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<SubFamiliaDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<SubFamiliaDTO>>
						(_mapper.Map<List<SubFamiliaDTO>>(await this._subfamiliaRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}



				public async Task<Response<List<SubFamiliaDTO>>> GetAllSubFamiliaByIdFamilia(Guid idFamilia)
				{
					try
					{
						return new Response<List<SubFamiliaDTO>>
					   (_mapper.Map<List<SubFamiliaDTO>>(await this._subfamiliaRepository.GetAllSubFamiliaByIdFamilia(idFamilia)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<SubFamiliaDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<SubFamiliaDTO>
						(_mapper.Map<SubFamiliaDTO>(await this._subfamiliaRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(SubFamiliaDTO subfamiliaDTO)
				{
					try
					{
						var result = _mapper.Map<SubFamilia>(subfamiliaDTO);
						result.IdSubFamilia = Guid.NewGuid();
						await _subfamiliaRepository.AddAsync(result);
						return new Response<Guid>(result.IdSubFamilia, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(SubFamiliaDTO subfamiliaDTO)
				{
					try
					{
						var result = _mapper.Map<SubFamilia>(subfamiliaDTO);
						await _subfamiliaRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdSubFamilia, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(SubFamiliaDTO subfamiliaDTO)
				{
					try
					{
						var result = _mapper.Map<SubFamilia>(subfamiliaDTO);
						await _subfamiliaRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdSubFamilia,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
