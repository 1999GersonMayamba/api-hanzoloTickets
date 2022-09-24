/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:47
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
		public class FamiliaController : BaseApiController
		{
				private readonly IFamiliaService _familiaService;


				public FamiliaController(IFamiliaService familiaService)
				{
					this._familiaService = familiaService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _familiaService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _familiaService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(FamiliaDTO request)
				{
						return Ok(await _familiaService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(FamiliaDTO request)
				{
						return Ok(await _familiaService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(FamiliaDTO request)
				{
						return Ok(await _familiaService.UpdateAsync(request));
				}


		}
}
