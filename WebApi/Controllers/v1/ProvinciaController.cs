/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:47
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
		public class ProvinciaController : BaseApiController
		{
				private readonly IProvinciaService _provinciaService;


				public ProvinciaController(IProvinciaService provinciaService)
				{
					this._provinciaService = provinciaService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _provinciaService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _provinciaService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(ProvinciaDTO request)
				{
						return Ok(await _provinciaService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(ProvinciaDTO request)
				{
						return Ok(await _provinciaService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(ProvinciaDTO request)
				{
						return Ok(await _provinciaService.UpdateAsync(request));
				}


		}
}
