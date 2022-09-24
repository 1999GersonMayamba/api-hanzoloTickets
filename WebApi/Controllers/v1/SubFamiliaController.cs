/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:08
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
		public class SubFamiliaController : BaseApiController
		{
				private readonly ISubFamiliaService _subfamiliaService;


				public SubFamiliaController(ISubFamiliaService subfamiliaService)
				{
					this._subfamiliaService = subfamiliaService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _subfamiliaService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _subfamiliaService.GetById(id));
				}


				[HttpGet("ByFamilia/{IdFamilia}")]
				public async Task<IActionResult> GetByFamilia(Guid IdFamilia)
				{
					return Ok(await _subfamiliaService.GetAllSubFamiliaByIdFamilia(IdFamilia));
				}



				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(SubFamiliaDTO request)
				{
						return Ok(await _subfamiliaService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(SubFamiliaDTO request)
				{
						return Ok(await _subfamiliaService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(SubFamiliaDTO request)
				{
						return Ok(await _subfamiliaService.UpdateAsync(request));
				}


		}
}
