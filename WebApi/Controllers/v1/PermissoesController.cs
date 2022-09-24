/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:22
*/

using Application.DTOs;
using Application.DTOs.Permissoes;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Permissoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers


{
			[ApiVersion("1.0")]
			public class PermissoesController : BaseApiController
			{
				private readonly IPermissoesService _permissoesService;


				public PermissoesController(IPermissoesService permissoesService)
				{
					this._permissoesService = permissoesService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _permissoesService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(int id)
				{
						return Ok(await _permissoesService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(PermissoesDTO request)
				{
						return Ok(await _permissoesService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(PermissoesDTO request)
				{
						return Ok(await _permissoesService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(PermissoesDTO request)
				{
						return Ok(await _permissoesService.UpdateAsync(request));
				}


		}
}
