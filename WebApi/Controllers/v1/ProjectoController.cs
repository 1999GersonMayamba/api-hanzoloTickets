/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:57
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
		public class ProjectoController : BaseApiController
		{
				private readonly IProjectoService _projectoService;


				public ProjectoController(IProjectoService projectoService)
				{
					this._projectoService = projectoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _projectoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _projectoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(ProjectoDTO request)
				{
						return Ok(await _projectoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(ProjectoDTO request)
				{
						return Ok(await _projectoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(ProjectoDTO request)
				{
						return Ok(await _projectoService.UpdateAsync(request));
				}


		}
}
