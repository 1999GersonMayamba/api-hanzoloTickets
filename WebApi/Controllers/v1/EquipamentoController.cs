/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:12
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
		public class EquipamentoController : BaseApiController
		{
				private readonly IEquipamentoService _equipamentoService;


				public EquipamentoController(IEquipamentoService equipamentoService)
				{
					this._equipamentoService = equipamentoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _equipamentoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _equipamentoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(EquipamentoDTO request)
				{
						return Ok(await _equipamentoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(EquipamentoDTO request)
				{
						return Ok(await _equipamentoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(EquipamentoDTO request)
				{
						return Ok(await _equipamentoService.UpdateAsync(request));
				}


		}
}
