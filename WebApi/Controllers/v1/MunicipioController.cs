/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:51
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
		public class MunicipioController : BaseApiController
		{
				private readonly IMunicipioService _municipioService;


				public MunicipioController(IMunicipioService municipioService)
				{
					this._municipioService = municipioService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _municipioService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _municipioService.GetById(id));
				}

				[HttpGet("ByProvincia/{IdProvincia}")]
				public async Task<IActionResult> GetAllByIdOProvincia(Guid IdProvincia)
				{
					return Ok(await _municipioService.GetAllByIdProvincia(IdProvincia));
				}


				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(MunicipioDTO request)
				{
						return Ok(await _municipioService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(MunicipioDTO request)
				{
						return Ok(await _municipioService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(MunicipioDTO request)
				{
						return Ok(await _municipioService.UpdateAsync(request));
				}


		}
}
