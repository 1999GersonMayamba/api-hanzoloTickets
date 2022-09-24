/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:16
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
		public class PrestadorUtilizadorController : BaseApiController
		{
				private readonly IPrestadorUtilizadorService _prestadorutilizadorService;


				public PrestadorUtilizadorController(IPrestadorUtilizadorService prestadorutilizadorService)
				{
					this._prestadorutilizadorService = prestadorutilizadorService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _prestadorutilizadorService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _prestadorutilizadorService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(PrestadorUtilizadorDTO request)
				{
						return Ok(await _prestadorutilizadorService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(PrestadorUtilizadorDTO request)
				{
						return Ok(await _prestadorutilizadorService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(PrestadorUtilizadorDTO request)
				{
						return Ok(await _prestadorutilizadorService.UpdateAsync(request));
				}


		}
}
