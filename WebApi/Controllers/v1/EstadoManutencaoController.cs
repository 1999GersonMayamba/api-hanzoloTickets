/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:42
*/

using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers


{
		[ApiVersion("1.0")]
		public class EstadoManutencaoController : BaseApiController
		{
				private readonly IEstadoManutencaoService _estadomanutencaoService;


				public EstadoManutencaoController(IEstadoManutencaoService estadomanutencaoService)
				{
					this._estadomanutencaoService = estadomanutencaoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _estadomanutencaoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _estadomanutencaoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(EstadoManutencaoDTO request)
				{
						return Ok(await _estadomanutencaoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(EstadoManutencaoDTO request)
				{
						return Ok(await _estadomanutencaoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(EstadoManutencaoDTO request)
				{
						return Ok(await _estadomanutencaoService.UpdateAsync(request));
				}


		}
}
