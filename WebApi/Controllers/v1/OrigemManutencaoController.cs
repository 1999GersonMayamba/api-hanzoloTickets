/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:52
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
		[Route("api/[controller]")]
		[ApiController]
		public class OrigemManutencaoController : BaseApiController
		{
				private readonly IOrigemManutencaoService _origemmanutencaoService;


				public OrigemManutencaoController(IOrigemManutencaoService origemmanutencaoService)
				{
					this._origemmanutencaoService = origemmanutencaoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _origemmanutencaoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _origemmanutencaoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(OrigemManutencaoDTO request)
				{
						return Ok(await _origemmanutencaoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(OrigemManutencaoDTO request)
				{
						return Ok(await _origemmanutencaoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(OrigemManutencaoDTO request)
				{
						return Ok(await _origemmanutencaoService.UpdateAsync(request));
				}


		}
}
