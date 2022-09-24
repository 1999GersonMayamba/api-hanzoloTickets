using Application.DTOs;
using Application.DTOs.Account;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);

        Task<Response<UpdateUserDTO>> UpdateAsync(UpdateUserDTO request, string origin);

        Task<Response<string>> EnableAsync(EnableUserDTO request, string origin);

        Task<List<string>> GetRoles();

        Task<Response<List<UserResponseDTO>>> GetUsers();
        Task<Response<List<UserRolesResponseDTO>>> GetUsersAndRoles();
        Task<Response<string>> RegisterRolesAndPermissionsAsync(RolesPermissionsUpdateDTO request);
        Task<Response<UserResponseDTO>> GetRolesAndPermissions(Guid id);
        Task<Response<UserResponseDTO>> GetUserByUserName(string UserName);
        Task<Response<List<UserRolesResponseDTO>>> GetUserByIdDominio(Guid IdDominio);
        Task<Response<List<UserResponseDTO>>> GetUserByIdUnidade(Guid IdUnidade);
        Task<Response<List<UserRolesResponseDTO>>> GetUsersByRole(string role);

    }
}
