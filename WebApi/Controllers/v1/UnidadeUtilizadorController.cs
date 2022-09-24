/*Gerado no Gerador de Codigo UCALL
Data: 11/03/2022 00:54:40
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
		public class UnidadeUtilizadorController : BaseApiController
		{
				private readonly IUnidadeUtilizadorService _unidadeutilizadorService;


				public UnidadeUtilizadorController(IUnidadeUtilizadorService unidadeutilizadorService)
				{
					this._unidadeutilizadorService = unidadeutilizadorService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _unidadeutilizadorService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _unidadeutilizadorService.GetById(id));
				}

				[HttpGet("ByEspecialidade/{IdUnidade}/{IdEspecialidade}")]
				public async Task<IActionResult> GetByEspecialidade(Guid IdUnidade, Guid IdEspecialidade)
				{
					return Ok(await _unidadeutilizadorService.GetAllUsersByEspecialidade(IdUnidade, IdEspecialidade));
				}





				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(UnidadeUtilizadorDTO request)
				{
						return Ok(await _unidadeutilizadorService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(UnidadeUtilizadorDTO request)
				{
						return Ok(await _unidadeutilizadorService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(UnidadeUtilizadorDTO request)
				{
						return Ok(await _unidadeutilizadorService.UpdateAsync(request));
				}


		}
}
