/*Gerado no Gerador de Codigo UCALL
Data: 10/04/2022 01:20:32
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
	public class ZonaController : BaseApiController
    {
				private readonly IZonaService _zonaService;


				public ZonaController(IZonaService zonaService)
				{
					this._zonaService = zonaService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _zonaService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _zonaService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(ZonaDTO request)
				{
						return Ok(await _zonaService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(ZonaDTO request)
				{
						return Ok(await _zonaService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(ZonaDTO request)
				{
						return Ok(await _zonaService.UpdateAsync(request));
				}


		}
}
