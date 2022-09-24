/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 14:11:12
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
		public class PrioridadeController : BaseApiController
		{
				private readonly IPrioridadeService _prioridadeService;


				public PrioridadeController(IPrioridadeService prioridadeService)
				{
					this._prioridadeService = prioridadeService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _prioridadeService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _prioridadeService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(PrioridadeDTO request)
				{
						return Ok(await _prioridadeService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(PrioridadeDTO request)
				{
						return Ok(await _prioridadeService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(PrioridadeDTO request)
				{
						return Ok(await _prioridadeService.UpdateAsync(request));
				}


		}
}
