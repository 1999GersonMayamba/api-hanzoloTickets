/*Gerado no Gerador de Codigo UCALL
Data: 19/03/2022 13:19:40
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
		public class GrupoSexoController : BaseApiController
		{
				private readonly IGrupoSexoService _gruposexoService;


				public GrupoSexoController(IGrupoSexoService gruposexoService)
				{
					this._gruposexoService = gruposexoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _gruposexoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _gruposexoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(GrupoSexoDTO request)
				{
						return Ok(await _gruposexoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(GrupoSexoDTO request)
				{
						return Ok(await _gruposexoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(GrupoSexoDTO request)
				{
						return Ok(await _gruposexoService.UpdateAsync(request));
				}


		}
}
