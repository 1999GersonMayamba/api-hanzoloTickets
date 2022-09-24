/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:53
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
		public class UnidadeService : IUnidadeService
		{
				private readonly IFileService _fileService;
				private readonly IMapper _mapper;
				private readonly IUnidadeRepository _unidadeRepository;


				private ILog logger;
				public UnidadeService(IUnidadeRepository unidadeRepository, IMapper mapper, ILog logger, IFileService fileService)
				{
						_mapper = mapper;
						this._unidadeRepository = unidadeRepository;
						this.logger = logger;
						this._fileService = fileService;
				}


				public async Task<Response<List<UnidadeRequestDTO>>> GetAll()
				{
					try
					{
						 return new Response<List<UnidadeRequestDTO>>(await this._unidadeRepository.GetAllDominios());
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<List<UnidadeRequestDTO>>> GetByDominio(Guid IdDominio)
				{
					try
					{
						return new Response<List<UnidadeRequestDTO>>
						(await this._unidadeRepository.GetAllUnidadesByDominio(IdDominio));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<PagedResponse<List<UnidadeRequestDTO>>> GetAllUnidadePagination(PaginationFilter paginationFilter)
				{
					try
					{
						return await this._unidadeRepository.GetAllUnidadePagination(paginationFilter);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}

				public async Task<Response<UnidadeDTO>> GetById(Guid id)
				{
					try
					{
						 return new Response<UnidadeDTO>
						(_mapper.Map<UnidadeDTO>(await this._unidadeRepository.GetByGUIDAsync(id)));
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RegisterAsync(UnidadeDTO unidadeDTO)
				{
					try
					{
						var result = _mapper.Map<Unidade>(unidadeDTO);
						result.IdUnidade = Guid.NewGuid();
						var total = await _unidadeRepository.GetCountUnidades();
						var sum = 0000 + total;
						sum = sum == 0 ? 1 : sum;
						result.CodAgencia = sum.ToString("D4");
						await _unidadeRepository.AddAsync(result);
						return new Response<Guid>(result.IdUnidade, Constantes.Constantes.RegistoSalvo);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> RemoveAsync(UnidadeDTO unidadeDTO)
				{
					try
					{
						var result = _mapper.Map<Unidade>(unidadeDTO);
						await _unidadeRepository.DeleteAsync(result);
						return new Response<Guid>(result.IdUnidade, Constantes.Constantes.RegistoEliminado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


				public async Task<Response<Guid>> UpdateAsync(UnidadeDTO unidadeDTO)
				{
					try
					{
						var result = _mapper.Map<Unidade>(unidadeDTO);
						await _unidadeRepository.UpdateAsync(result);
						return new Response<Guid>(result.IdUnidade,  Constantes.Constantes.RegistoActualizado);
					}
					catch (System.Exception ex)
					{
						this.logger.Error(ex.Message);
						throw new ApiException(ex.Message);
					}
				}


		}
}
