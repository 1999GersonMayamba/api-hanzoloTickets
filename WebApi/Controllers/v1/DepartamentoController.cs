/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:54
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
		public class DepartamentoController : BaseApiController
		{
				private readonly IDepartamentoService _departamentoService;


				public DepartamentoController(IDepartamentoService departamentoService)
				{
					this._departamentoService = departamentoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _departamentoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _departamentoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(DepartamentoDTO request)
				{
						return Ok(await _departamentoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(DepartamentoDTO request)
				{
						return Ok(await _departamentoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(DepartamentoDTO request)
				{
						return Ok(await _departamentoService.UpdateAsync(request));
				}


		}
}
