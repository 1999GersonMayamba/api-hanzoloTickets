/*Gerado no Gerador de Codigo UCALL
Data: 09/05/2022 00:13:40
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
		public class ComunaController : BaseApiController
		{
				private readonly IComunaService _comunaService;


				public ComunaController(IComunaService comunaService)
				{
					this._comunaService = comunaService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _comunaService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _comunaService.GetById(id));
				}



				[HttpGet("ByMunicpio/{idMunicipio}")]
				public async Task<IActionResult> GetComunaByMunicipio(Guid idMunicipio)
				{
					return Ok(await _comunaService.GetComunaByMunicipio(idMunicipio));
				}



				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(ComunaDTO request)
				{
						return Ok(await _comunaService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(ComunaDTO request)
				{
						return Ok(await _comunaService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(ComunaDTO request)
				{
						return Ok(await _comunaService.UpdateAsync(request));
				}


		}
}
