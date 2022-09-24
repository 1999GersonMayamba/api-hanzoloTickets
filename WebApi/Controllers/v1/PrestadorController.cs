/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:23
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
		public class PrestadorController : BaseApiController
		{
				private readonly IPrestadorService _prestadorService;


				public PrestadorController(IPrestadorService prestadorService)
				{
					this._prestadorService = prestadorService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _prestadorService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _prestadorService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(PrestadorDTO request)
				{
						return Ok(await _prestadorService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(PrestadorDTO request)
				{
						return Ok(await _prestadorService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(PrestadorDTO request)
				{
						return Ok(await _prestadorService.UpdateAsync(request));
				}


		}
}
