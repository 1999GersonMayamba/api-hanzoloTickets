/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:18
*/

using Application.DTOs;
using Application.Interfaces.Services;
using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers


{
		[ApiVersion("1.0")]
		public class ManutencaoController : BaseApiController
		{
				private readonly IManutencaoService _manutencaoService;


				public ManutencaoController(IManutencaoService manutencaoService)
				{
					this._manutencaoService = manutencaoService;
				}




				[HttpGet]
				public async Task<IActionResult> GetAll()
				{
						return Ok(await _manutencaoService.GetAll());
				}




				[HttpGet("{id}")]
				public async Task<IActionResult> GetById(Guid id)
				{
						return Ok(await _manutencaoService.GetById(id));
				}

				[HttpGet("ByUnidade")]
				public async Task<IActionResult> GetByUnidadeId([FromQuery] ManutencaoFilterPaginationDTO filter)
				{
					return Ok(await _manutencaoService.GetAllByUnidade(filter));
				}

				[HttpGet("Dashboard")]
				public async Task<IActionResult> GetDashboard()
				{
					return Ok(await _manutencaoService.GetDashBoard());
				}


				[HttpGet("ByUnidadeSimple/{IdUnidade}")]
				public async Task<IActionResult> GetAllByUnidadeSimple(Guid IdUnidade)
				{
					return Ok(await _manutencaoService.GetAllManutencaoByUnidadeSimple(IdUnidade));
				}

				[HttpGet("Pagination")]
				public async Task<IActionResult> GetByUnidadeId([FromQuery] PaginationFilter filter)
				{
					return Ok(await _manutencaoService.GetAllManutencaoPagination(filter));
				}

				[HttpGet("Filter")]
				public async Task<IActionResult> GetFilterManutencoes([FromQuery] FilterTicketsDTO filter)
				{
					return Ok(await _manutencaoService.FilterManutencoes(filter));
				}

				[HttpGet("PreventivaFilter")]
				public async Task<IActionResult> GetFilterManutencoesPreventiva([FromQuery] FilterTicketsDTO filter)
				{
					return Ok(await _manutencaoService.FilterManutencoesPreventiva(filter));
				}

				[HttpGet("All")]
				public async Task<IActionResult> GetAllData()
				{
					return Ok(await _manutencaoService.GetAllManutencao());
				}



				[HttpPost("register")]
				public async Task<IActionResult> RegisterAsync(ManutencaoDTO request)
				{
						return Ok(await _manutencaoService.RegisterAsync(request));
				}

				[HttpPost("register/All")]
				public async Task<IActionResult> RegisterAllAsync(ManutencaoAddDTO request)
				{
					return Ok(await _manutencaoService.RegisterAllAsync(request));
				}

				[HttpPost("registerManutencaoPreventiva/All")]
				public async Task<IActionResult> RegisterAllManutencaoPreventivaAsync(ManutencaoPreventivaAddDTO request)
				{
					return Ok(await _manutencaoService.RegisterAllManutencaoPreventivaAsync(request));
				}

				[HttpGet("AllManutencaoPreventiva")]
				public async Task<IActionResult> GetAllManutencaoPreventivaAsync([FromQuery] PaginationFilter filter)
				{
					return Ok(await _manutencaoService.GetAllManutencaoPreventivaPagination(filter));
				}



				[HttpDelete("delete")]
				public async Task<IActionResult> DeleyteAsync(ManutencaoDTO request)
				{
						return Ok(await _manutencaoService.RemoveAsync(request));
				}




				[HttpPut("update")]
				public async Task<IActionResult> UpdateteAsync(ManutencaoDTO request)
				{
						return Ok(await _manutencaoService.UpdateAsync(request));
				}

				[HttpPut("UpdateStateTicket")]
				public async Task<IActionResult> UpdateStateTicketAsync(TicketUpdateEstadoDTO request)
				{
					return Ok(await _manutencaoService.UpdateStateTicket(request));
				}

				[HttpPut("AssignToUsersTicket")]
				public async Task<IActionResult> AssignToUsersTicketAsync(AssignToUsersTicketDTO request)
				{
					return Ok(await _manutencaoService.AssignToUsersTicket(request));
				}


		}
}
