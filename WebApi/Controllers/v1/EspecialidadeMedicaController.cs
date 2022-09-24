/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:59
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
		public class EspecialidadeMedicaController : BaseApiController
		{
				private readonly IEspecialidadeMedicaService _especialidademedicaService;


				public EspecialidadeMedicaController(IEspecialidadeMedicaService especialidademedicaService)
				{
					this._especialidademedicaService = especialidademedicaService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _especialidademedicaService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _especialidademedicaService.GetById(id));
				}


				[HttpGet("ByDepartamento/{IdDepartamento}")]
				public async Task<IActionResult> GetByDepartamento(Guid IdDepartamento)
				{
					return Ok(await _especialidademedicaService.GetAllEspecialidadeByDepartamento(IdDepartamento));
				}

				[HttpGet("ByDepartamentoAndUnidade/{IdDepartamento}/{Unidade}")]
				public async Task<IActionResult> GetByDepartamentoAndUnidade(Guid IdDepartamento, Guid Unidade)
				{
					return Ok(await _especialidademedicaService.GetAllEspecialidadeByDepartamentoAndIdUnidade(IdDepartamento, Unidade));
				}

				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(EspecialidadeMedicaDTO request)
				{
						return Ok(await _especialidademedicaService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(EspecialidadeMedicaDTO request)
				{
						return Ok(await _especialidademedicaService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(EspecialidadeMedicaDTO request)
				{
						return Ok(await _especialidademedicaService.UpdateAsync(request));
				}


		}
}
