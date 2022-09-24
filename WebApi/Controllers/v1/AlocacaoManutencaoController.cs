/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:44:55
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
		public class AlocacaoManutencaoController : BaseApiController
		{
				private readonly IAlocacaoManutencaoService _alocacaomanutencaoService;


				public AlocacaoManutencaoController(IAlocacaoManutencaoService alocacaomanutencaoService)
				{
					this._alocacaomanutencaoService = alocacaomanutencaoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _alocacaomanutencaoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _alocacaomanutencaoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(AlocacaoManutencaoDTO request)
				{
						return Ok(await _alocacaomanutencaoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(AlocacaoManutencaoDTO request)
				{
						return Ok(await _alocacaomanutencaoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(AlocacaoManutencaoDTO request)
				{
						return Ok(await _alocacaomanutencaoService.UpdateAsync(request));
				}


		}
}
