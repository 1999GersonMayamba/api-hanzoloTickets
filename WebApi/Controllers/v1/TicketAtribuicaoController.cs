/*Gerado no Gerador de Codigo UCALL
Data: 28/05/2022 08:24:37
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
		public class TicketAtribuicaoController : BaseApiController
		{
				private readonly ITicketAtribuicaoService _ticketatribuicaoService;


				public TicketAtribuicaoController(ITicketAtribuicaoService ticketatribuicaoService)
				{
					this._ticketatribuicaoService = ticketatribuicaoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _ticketatribuicaoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _ticketatribuicaoService.GetById(id));
				}




				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(TicketAtribuicaoDTO request)
				{
						return Ok(await _ticketatribuicaoService.RegisterAsync(request));
				}




				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(TicketAtribuicaoDTO request)
				{
						return Ok(await _ticketatribuicaoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(TicketAtribuicaoDTO request)
				{
						return Ok(await _ticketatribuicaoService.UpdateAsync(request));
				}


		}
}
