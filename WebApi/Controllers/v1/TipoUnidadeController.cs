/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 11:37:40
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
		public class TipoUnidadeController : BaseApiController
		{
				private readonly ITipoUnidadeService _tipounidadeService;


				public TipoUnidadeController(ITipoUnidadeService tipounidadeService)
				{
					this._tipounidadeService = tipounidadeService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _tipounidadeService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _tipounidadeService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(TipoUnidadeDTO request)
				{
						return Ok(await _tipounidadeService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(TipoUnidadeDTO request)
				{
						return Ok(await _tipounidadeService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(TipoUnidadeDTO request)
				{
						return Ok(await _tipounidadeService.UpdateAsync(request));
				}


		}
}
