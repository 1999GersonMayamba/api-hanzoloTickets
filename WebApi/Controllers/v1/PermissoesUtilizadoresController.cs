/*Gerado no Gerador de Codigo UCALL
Data: 23/06/2021 09:22:17
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
			public class PermissoesUtilizadoresController : BaseApiController
			{
				private readonly IPermissoesUtilizadoresService _permissoesutilizadoresService;


				public PermissoesUtilizadoresController(IPermissoesUtilizadoresService permissoesutilizadoresService)
				{
					this._permissoesutilizadoresService = permissoesutilizadoresService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _permissoesutilizadoresService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _permissoesutilizadoresService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(PermissoesUtilizadoresDTO request)
				{
						return Ok(await _permissoesutilizadoresService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(PermissoesUtilizadoresDTO request)
				{
						return Ok(await _permissoesutilizadoresService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(PermissoesUtilizadoresDTO request)
				{
						return Ok(await _permissoesutilizadoresService.UpdateAsync(request));
				}


		}
}
