/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:53
*/

using Application.DTOs;
using Application.Interfaces.Services;
using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers


{
		[ApiVersion("1.0")]
		public class UnidadeController : BaseApiController
		{
				private readonly IUnidadeService _unidadeService;


				public UnidadeController(IUnidadeService unidadeService)
				{
					this._unidadeService = unidadeService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _unidadeService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _unidadeService.GetById(id));
				}


				[HttpGet("GetByDominio/{IdDominio}")]
				public async Task<IActionResult> GetByDominio(Guid IdDominio)
				{
					return Ok(await _unidadeService.GetByDominio(IdDominio));
				}

				[HttpGet("Pagination")]
				public async Task<IActionResult> GetByDominio([FromQuery] PaginationFilter filter )
				{
					return Ok(await _unidadeService.GetAllUnidadePagination(filter));
				}


				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(UnidadeDTO request)
				{
						return Ok(await _unidadeService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(UnidadeDTO request)
				{
						return Ok(await _unidadeService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(UnidadeDTO request)
				{
						return Ok(await _unidadeService.UpdateAsync(request));
				}


		}
}
