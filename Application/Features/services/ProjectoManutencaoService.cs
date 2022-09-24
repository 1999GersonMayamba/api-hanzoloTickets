/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:23
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
		public class ProjectoManutencaoService : IProjectoManutencaoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IProjectoManutencaoRepository _projectomanutencaoRepository;


				private ILog logger;
				public ProjectoManutencaoService(IProjectoManutencaoRepository projectomanutencaoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._projectomanutencaoRepository = projectomanutencaoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<ProjectoManutencaoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<ProjectoManutencaoDTO>>
						(_mapper.Map<List<ProjectoManutencaoDTO>>(await this._projectomanutencaoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<ProjectoManutencaoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<ProjectoManutencaoDTO>
						(_mapper.Map<ProjectoManutencaoDTO>(await this._projectomanutencaoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(ProjectoManutencaoDTO projectomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<ProjectoManutencao>(projectomanutencaoDTO);
						result.IdProjectoManutencao = Guid.NewGuid();
						await _projectomanutencaoRepository.AddAsync(result);
						return new Response<Guid>(result.IdProjectoManutencao, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(ProjectoManutencaoDTO projectomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<ProjectoManutencao>(projectomanutencaoDTO);
						await _projectomanutencaoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdProjectoManutencao, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(ProjectoManutencaoDTO projectomanutencaoDTO)
				{
					try
					{
						var result = _mapper.Map<ProjectoManutencao>(projectomanutencaoDTO);
						await _projectomanutencaoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdProjectoManutencao,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
