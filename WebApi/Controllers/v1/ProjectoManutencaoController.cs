/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:07:23
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
		[Route("api/[controller]")]
		[ApiController]
		public class ProjectoManutencaoController : BaseApiController
		{
				private readonly IProjectoManutencaoService _projectomanutencaoService;


				public ProjectoManutencaoController(IProjectoManutencaoService projectomanutencaoService)
				{
					this._projectomanutencaoService = projectomanutencaoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _projectomanutencaoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _projectomanutencaoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(ProjectoManutencaoDTO request)
				{
						return Ok(await _projectomanutencaoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(ProjectoManutencaoDTO request)
				{
						return Ok(await _projectomanutencaoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(ProjectoManutencaoDTO request)
				{
						return Ok(await _projectomanutencaoService.UpdateAsync(request));
				}


		}
}
