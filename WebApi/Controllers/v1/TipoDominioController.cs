/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:04
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
		public class TipoDominioController : BaseApiController
		{
				private readonly ITipoDominioService _tipodominioService;


				public TipoDominioController(ITipoDominioService tipodominioService)
				{
					this._tipodominioService = tipodominioService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _tipodominioService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _tipodominioService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(TipoDominioDTO request)
				{
						return Ok(await _tipodominioService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(TipoDominioDTO request)
				{
						return Ok(await _tipodominioService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(TipoDominioDTO request)
				{
						return Ok(await _tipodominioService.UpdateAsync(request));
				}


		}
}
