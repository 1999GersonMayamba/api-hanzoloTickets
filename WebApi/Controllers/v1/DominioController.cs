/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:44
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
		public class DominioController : BaseApiController
		{
				private readonly IDominioService _dominioService;


				public DominioController(IDominioService dominioService)
				{
					this._dominioService = dominioService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _dominioService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _dominioService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(DominioDTO request)
				{
						return Ok(await _dominioService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(DominioDTO request)
				{
						return Ok(await _dominioService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(DominioDTO request)
				{
						return Ok(await _dominioService.UpdateAsync(request));
				}


		}
}
