/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:57
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
		public class ProjectoService : IProjectoService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IProjectoRepository _projectoRepository;


				private ILog logger;
				public ProjectoService(IProjectoRepository projectoRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._projectoRepository = projectoRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<ProjectoDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<ProjectoDTO>>
						(_mapper.Map<List<ProjectoDTO>>(await this._projectoRepository.GetAllAsync()));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<ProjectoDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<ProjectoDTO>
						(_mapper.Map<ProjectoDTO>(await this._projectoRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(ProjectoDTO projectoDTO)
				{
					try
					{
						var result = _mapper.Map<Projecto>(projectoDTO);
						result.IdProjecto = Guid.NewGuid();
						await _projectoRepository.AddAsync(result);
						return new Response<Guid>(result.IdProjecto, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(ProjectoDTO projectoDTO)
				{
					try
					{
						var result = _mapper.Map<Projecto>(projectoDTO);
						await _projectoRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdProjecto, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(ProjectoDTO projectoDTO)
				{
					try
					{
						var result = _mapper.Map<Projecto>(projectoDTO);
						await _projectoRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdProjecto,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
