using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Account;
using Application.Interfaces;
using Application.Interfaces.NLog;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        readonly ILogger<AccountController> _log;
        private ILog logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> log, ILog logger)
        {
            _accountService = accountService;
            _log = log;
            this.logger = logger;
        }

        [HttpGet("users")]
        //[Authorize]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _accountService.GetUsers());
        }

        [HttpGet("GetUsersByDominio/{IdDominio}")]
        //[Authorize]
        public async Task<IActionResult> GetAllUsersByDominio(Guid IdDominio)
        {
            return Ok(await _accountService.GetUserByIdDominio(IdDominio));
        }

        [HttpGet("GetUsersByUnidade/{IdUnidade}")]
        //[Authorize]
        public async Task<IActionResult> GetAllUsersByUnidade(Guid IdUnidade)
        {
            return Ok(await _accountService.GetUserByIdUnidade(IdUnidade));
        }


        [HttpGet("usersAndRoles")]
        //[Authorize]
        public async Task<IActionResult> GetUsersAndRoles()
        {
            return Ok(await _accountService.GetUsersAndRoles());
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request, GenerateIPAddress()));
        }

        [HttpPost("register")]
        //[Authorize]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin));
        }


        [HttpPut("register")]
        //[Authorize]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserDTO request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.UpdateAsync(request, origin));
        }

        [HttpPut("enable")]
        [Authorize]
        public async Task<IActionResult> EnableUserAsync(EnableUserDTO request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.EnableAsync(request, origin));
        }


        [HttpGet("AllRoles")]
        //[Authorize]
        public async Task<IActionResult> GetRolesAsync()
        {
            //var origin = Request.Headers["origin"];
            return Ok(await _accountService.GetRoles());
        }

        //[HttpGet("confirm-email")]
        //public async Task<IActionResult> ConfirmEmailAsync([FromQuery]string userId, [FromQuery]string code)
        //{
        //    var origin = Request.Headers["origin"];
        //    return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        //}
        //[HttpPost("forgot-password")]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        //{
        //    await _accountService.ForgotPassword(model, Request.Headers["origin"]);
        //    return Ok();
        //}
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            return Ok(await _accountService.ResetPassword(model));
        }
        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [HttpPost("usersAddRolesAndPermissions")]
        //[Authorize]
        public async Task<IActionResult> AddPermissionsAndRoles(RolesPermissionsUpdateDTO rolesPermissionsUpdateDTO)
        {
            return Ok(await _accountService.RegisterRolesAndPermissionsAsync(rolesPermissionsUpdateDTO));
        }

        [HttpGet("RolesAndPermissions/{IdUser}")]
        //[Authorize]
        public async Task<IActionResult> GetRolesAndPermisionsAsync(Guid IdUser)
        {
            //var origin = Request.Headers["origin"];
            return Ok(await _accountService.GetRolesAndPermissions(IdUser));
        }

        [HttpGet("Roles")]
        //[Authorize]
        public async Task<IActionResult> GetRoles(Guid IdUser)
        {
            //var origin = Request.Headers["origin"];
            return Ok(await _accountService.GetRoles());
        }

        [HttpGet("UsersByRole")]
        //[Authorize]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            //var origin = Request.Headers["origin"];
            return Ok(await _accountService.GetUsersByRole(role));
        }


        //[Authorize]
        //[HttpPost, Route("adicionarGrupo")]
        //public async Task<IActionResult> AdicionarGrupo(AppUserBasicInfoDTO dto)
        //{
        //        return Ok(await _accountService.AdicionarGruposPermissoes(dto));

        //}

    }
}