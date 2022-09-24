using Application.DTOs.Account;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Infrastructure.Identity.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Enums;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Application.DTOs.Email;
using Application.Interfaces.Repositories;
using Application.Constantes;
using System.Web;
using Domain.Identity.Entities;
using Application.Interfaces.Services.Permissoes;
using Application.Interfaces.NLog;
using Application.DTOs.Permissoes;
using AutoMapper;
using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IEmailService _emailService;
        private readonly JWTSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;
        private ILog _logger;
        private readonly IFileService _fileService;
        private readonly IPermissoesUtilizadoresService _permissoesUtilizadoresService;
        //private readonly IDominioRepository _dominioRepository;
        private readonly IDominioService _dominioService;
        private readonly IUnidadeUtilizadorRepository _unidadeUtilizadorRepository;
        private readonly IPrestadorUtilizadorRepository _prestadorUtilizadorRepository;

        public AccountService(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<JWTSettings> jwtSettings, 
            IDateTimeService dateTimeService,
            IPermissoesUtilizadoresService permissoesUtilizadoresService,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            IMapper mapper,
            ILog logger,
            IFileService fileService,
            IDominioService dominioService,
            IUnidadeUtilizadorRepository unidadeUtilizadorRepository,
            IPrestadorUtilizadorRepository prestadorUtilizadorRepository
            //IColaboradorRepository colaboradorRepository
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
            _signInManager = signInManager;
            this._permissoesUtilizadoresService = permissoesUtilizadoresService;
            this._emailService = emailService;
            this._logger = logger;
            this._fileService = fileService;
            _mapper = mapper;
            this._dominioService = dominioService;
            this._unidadeUtilizadorRepository = unidadeUtilizadorRepository;
            this._prestadorUtilizadorRepository = prestadorUtilizadorRepository;
            //this._colaboradorRepository = colaboradorRepository;
        }


        public async Task<Response<List<UserResponseDTO>>> GetUsers()
        {
            var useres = _userManager.Users;
            var response = new List<UserResponseDTO>();
            foreach (var user in useres )
            {
                UserResponseDTO u = new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PeerdID=user.PeerID,
                    //Colaborador = await this._colaboradorRepository.GetColaboradorByUser(user.Id)
                };
                response.Add(u);
            }
            
            return new Response<List<UserResponseDTO>>(response, $"List of all users");
        }
        
        public async Task<Response<UserResponseDTO>> GetUserByUserName(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                throw new ApiException($"Username Não encontrado.");
            }
            else
            {
                UserResponseDTO u = new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PeerdID = user.PeerID,
                    Nome = user.Nome
                    //Colaborador = await this._colaboradorRepository.GetColaboradorByUser(user.Id)
                };

                return new Response<UserResponseDTO>(u, $"User");
            }

        }
        public async Task<Response<List<UserRolesResponseDTO>>> GetUsersAndRoles()
        {

            

            var Users = _userManager.Users.Select(user => new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName

            }).ToList();

            var response = new List<UserRolesResponseDTO>();


                foreach(var user in Users)
                {

                
                    var Roles = await _userManager.GetRolesAsync(user);
                    var RoleslIst = new List<IdentityRoleDTO>();

                    foreach (var role in Roles)
                    {
                        var x = _roleManager.Roles.Where(x => x.Name == role).FirstOrDefault();
                        IdentityRoleDTO Urole = new IdentityRoleDTO
                        {
                            Id = x.Id,
                            Name = x.Name
                        };
                            RoleslIst.Add(Urole);
                        }

                    UserRolesResponseDTO u = new UserRolesResponseDTO
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Roles = RoleslIst
                    };

                    response.Add(u);
                    //RoleslIst.Clear();
                }
          

            return new Response<List<UserRolesResponseDTO>>(response, $"List of all users");
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new ApiException($"Nenhuma conta registrada como o username :  {request.UserName}.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"´credenciais erradas '{request.UserName}'.");
            }
            if (!user.EmailConfirmed)
            {
                throw new ApiException($"Account Not Confirmed for '{request.Email}'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            //response.Colaborador = await this._colaboradorRepository.GetColaboradorByUser(user.Id);
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.UserName = user.UserName;
            response.PeerdID = user.PeerID;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;
            var UserPermissoes = await this._permissoesUtilizadoresService.GetPermissionsByIdUser(Guid.Parse(response.Id));
            response.Permissoes = UserPermissoes;
            var domain = !user.IdDominio.HasValue ? null : await _dominioService.GetById(user.IdDominio.Value);
            response.Dominio = domain == null ? null : domain.Data;
            response.Unidades = await this._unidadeUtilizadorRepository.GetUsersByIdUser(user.Id);
            response.Prestadores = await this._prestadorUtilizadorRepository.GetPrestadorByIdUser(user.Id);
               // await this._unidadeUtilizadorRepository.GetUsersByIdUser(user.Id);
            //response.Dominio =  await this._utilizadoreDominioRepository.GetDominioByUserUser(user.Id);

            return new Response<AuthenticationResponse>(response, $"Authenticated {user.UserName}");
        }


        //public async Task<Response<string>> REstartAsync(RestartUserDTO request, string origin)
        //{

        //    var user = await _userManager.FindByIdAsync(request.UserId);
        //    if (user != null)
        //    {
        //        //var dataProtectionProvider = AuthProtectionProvider.DataProtectionProvider;
        //        var code = _userManager.GeneratePasswordResetTokenAsync(user.Id);

        //        var result = _userManager.ResetPasswordAsync(user.Id, code, "123456");
        //        if (result.Succeeded)
        //        {
                  

        //            return new Response<string>($"{user.FirstName}{" "}{user.LastName}", message: $"Utilizador alterado com sucesso!");
        //        }
        //        else
        //        {
        //            throw new ApiException($"{result.Errors}");
        //        }
        //    }
        //    else
        //    {
        //        throw new ApiException($"Utilizador {request.UserId} Não encontrado.");
        //    }
        //}


        public async Task<Response<string>> EnableAsync(EnableUserDTO request, string origin)
        {

            var user= await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                user.IsActivo = request.IsActivo;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    
                    return new Response<string>($"{user.FirstName}{" "}{user.LastName}", message: $"Utilizador alterado com sucesso!");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }
            else
            {
                throw new ApiException($"Utilizador {request.UserId} Não encontrado.");
            }
        }

        public async Task<Response<UpdateUserDTO>> UpdateAsync(UpdateUserDTO request, string origin)
        {

            var user= await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                user.Email = request.Email;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName = request.UserName;
                user.PeerID = request.PeerID;
                user.Nome = request.Nome;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new Response<UpdateUserDTO>(request, message: $"Utilizador alterado com sucesso!");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }
            else
            {
                throw new ApiException($"Utilizador {request.Email } Não encontrado.");
            }
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                throw new ApiException($"Username '{request.UserName}' ja em uso.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                IsActivo = true,
                EmailConfirmed = true,
                Nome = request.Nome,
                IdDominio = !request.IdDominio.HasValue ? null : request.IdDominio.Value
                
            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                    //await _userManager.AddToRolesAsync(user, request.Roles);


                    //var verificationUri = await SendVerificationEmail(user, origin);
                    //TODO: Attach Email Service here and configure it via appsettings
                    //await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest() { From = "mail@codewithmukesh.com", To = user.Email, Body = $"Please confirm your account by visiting this URL {verificationUri}", Subject = "Confirm Registration" });
                    return new Response<string>($"{user.FirstName}{" "}{user.LastName}", message: $"Utilizador registrado com sucesso!");
                }
                else
                {
                    //Se ocorrer um ERRO ao criar a conta de utilizador
                    var Erros = result.Errors.FirstOrDefault(); //Captar a mensagem de erro
                    switch(Erros.Code)
                    {
                        case "PasswordRequiresUpper":
                            throw new ApiException($"{Constantes.MsgErroCaracterDeSenhaMaisculo}");
                        case "PasswordRequiresNonAlphanumeric":
                            throw new ApiException($"{Constantes.MsgErroCaracterDeSenhaEspecial}");
                        case "PasswordRequiresDigit":
                            throw new ApiException($"{Constantes.MsgErroCaracterDeSenhaNumerico}");
                        default:
                            throw new ApiException($"{Erros.Description}" + " " + Erros.Code);
                    }

                    //throw new ApiException($"{Erros.Description}" + " " + Erros.Code);
                }
            }
            else
            {
                throw new ApiException($"Email {request.Email } ja em uso.");
            }
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.DurationInDays),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
        
        private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/account/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            //Email Service Call Here
            return verificationUri;
        }

        public async Task<List<string>> GetRoles()
        {
            List<string> rolesList = new List<string>();
            var roles = _roleManager.Roles.ToList();
            foreach(var role in roles)
            {
                rolesList.Add(role.Name);
            }
            return await Task.FromResult((rolesList));

        }

        public async Task<Response<string>> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if(result.Succeeded)
            {
                return new Response<string>(user.Id, message: $"Account Confirmed for {user.Email}. You can now use the /api/Account/authenticate endpoint.");
            }
            else
            {
                throw new ApiException($"An error occured while confirming {user.Email}.");
            }
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = await _userManager.FindByEmailAsync(model.Email);

            // always return ok response to prevent email enumeration
            if (account == null) return;

            var code = await _userManager.GeneratePasswordResetTokenAsync(account);
            var route = "api/account/reset-password/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var emailRequest = new EmailRequest()
            {
                Body = $"You reset token is - {code}",
                To = model.Email,
                Subject = "Reset Password",
            };
            await _emailService.SendAsync(emailRequest);
        }

        public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
        {
            var account = await _userManager.FindByNameAsync(model.UserName);
            if (account == null) throw new ApiException($"No Accounts Registered with {model.UserName}.");

            //Gerar chave de TOKEN para poder fazer RESET da password do utilizador
            string TokenForResetPasswordUser = await _userManager.GeneratePasswordResetTokenAsync(account);
            var result = await _userManager.ResetPasswordAsync(account, TokenForResetPasswordUser, model.Password);

            if (result.Succeeded)
            {
                return new Response<string>(model.UserName, message: $"Password Resetted.");
            }
            else
            {
                throw new ApiException($"Error occured while reseting the password.");
            }
        }

        public async Task<Response<UserResponseDTO>> GetRolesAndPermissions(Guid id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                var response = new List<UserResponseDTO>();

                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                UserResponseDTO u = new UserResponseDTO
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    UserName = user.UserName,
                    PeerdID = user.PeerID,
                    //Colaborador = await this._colaboradorRepository.GetColaboradorByUser(user.Id),
                    IsActivo = user.IsActivo,
                    Roles = rolesList.ToList(),
                    Permissoes = await this._permissoesUtilizadoresService.GetPermissionsByIdUser(Guid.Parse(user.Id))
                };


                return new Response<UserResponseDTO>(u, $"User");
            }
            catch (System.Exception ex)
            {
                this._logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        private async Task<Response<UserResponseDTO>> GetRolesAndPermissionsTwo(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var response = new List<UserResponseDTO>();

                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                UserResponseDTO u = new UserResponseDTO
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    UserName = user.UserName,
                    PeerdID = user.PeerID,
                    //Colaborador = await this._colaboradorRepository.GetColaboradorByUser(user.Id),
                    IsActivo = user.IsActivo,
                    Roles = rolesList.ToList(),
                    Permissoes = await this._permissoesUtilizadoresService.GetPermissionsByIdUser(Guid.Parse(user.Id))
                };


                return new Response<UserResponseDTO>(u, $"User");
            }
            catch (System.Exception ex)
            {
                this._logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<string>> RegisterRolesAndPermissionsAsync(RolesPermissionsUpdateDTO request)
        {

            try
            {
                var user = await _userManager.FindByIdAsync(request.IdUser.ToString());
                if (user != null)
                {
                    //Eliminar todas a roles de um determinado User
                    var roles = await _userManager.GetRolesAsync(user);
                    var AddRolesResult = await _userManager.RemoveFromRolesAsync(user, roles.ToArray());

                    //Eliminar todas as permissões de um determinado User
                    var UserPermissoes = await this._permissoesUtilizadoresService.DeleteAllPermissionsForUser(request.IdUser);

                    //Adicionar roles para o usuário
                    await _userManager.AddToRolesAsync(user, request.Roles);

                    //Adicionar permissões para o utilizador
                    var UserPermissoesDTO = _mapper.Map<List<PermissoesUtilizadoresDTO>>(request.Permissoes);

                    var delete = await this._permissoesUtilizadoresService.DeleteAllPermissionsForUser(request.IdUser);//Rever isto

                    var AddPermissoesResult = await this._permissoesUtilizadoresService.RegisterRangeAsync(UserPermissoesDTO, request.IdUser);

                    //Adicionar permissoes para o utilizador

                    return new Response<string>($"Permissões e Roles adicionados com sucesso");

                }
                else
                {
                    return new Response<string>($"Usuario não encontrado");

                }

            }
            catch (System.Exception ex)
            {
                this._logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
            //return new Response<UserResponseDTO>(null, $"Not FOUND");


        }


        public async Task<Response<List<UserRolesResponseDTO>>> GetUserByIdDominio(Guid IdDominio)
        {



            var Users = _userManager.Users.Where(x => x.IdDominio == IdDominio).Select(user => new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                IdDominio = user.IdDominio


            }).ToList();


            var response = new List<UserRolesResponseDTO>();


            foreach (var user in Users)
            {


                var Roles = await _userManager.GetRolesAsync(user);
                var RoleslIst = new List<IdentityRoleDTO>();

                foreach (var role in Roles)
                {
                    var x = _roleManager.Roles.Where(x => x.Name == role).FirstOrDefault();
                    IdentityRoleDTO Urole = new IdentityRoleDTO
                    {
                        Id = x.Id,
                        Name = x.Name
                    };
                    RoleslIst.Add(Urole);
                }

                    UserRolesResponseDTO u = new UserRolesResponseDTO
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Roles = RoleslIst
                    };

                    var domain = !user.IdDominio.HasValue ? null : await _dominioService.GetById(user.IdDominio.Value);
                    u.Dominio = domain == null ? null : domain.Data;
                    u.Unidades = await this._unidadeUtilizadorRepository.GetUsersByIdUser(user.Id);

                response.Add(u);
                //RoleslIst.Clear();
            }



            return new Response<List<UserRolesResponseDTO>>(response, $"List of all users");
        }

        public async Task<Response<List<UserResponseDTO>>> GetUserByIdUnidade(Guid IdUnidade)
        {

            List<UserResponseDTO> userResponseDTOs = new List<UserResponseDTO>();
            var usser = await this._unidadeUtilizadorRepository.GetUnidadesByIdUser(IdUnidade);
            foreach(var us in usser)
            {
                var uu = await this.GetRolesAndPermissionsTwo(us.IdUser);
                userResponseDTOs.Add(uu.Data);
            }


            return new Response<List<UserResponseDTO>>(userResponseDTOs, $"List of all users");
        }

        public async Task<Response<List<UserRolesResponseDTO>>> GetUsersByRole(string role)
        {


            var response = new List<UserRolesResponseDTO>();
            var Users = await _userManager.GetUsersInRoleAsync(role);
                
            foreach(var user in Users)
            {

                UserRolesResponseDTO u = new UserRolesResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Nome = user.Nome,
                    Email = user.Email
                };

                response.Add(u);

            }
               
            return new Response<List<UserRolesResponseDTO>>(response, $"List of all users");
        }

        //public async Task<Response<string>> AdicionarGruposPermissoes(AppUserBasicInfoDTO dto)
        //{


        //    try
        //    {

        //        var user = await _userManager.FindByIdAsync(dto.Id);
        //        if(user == null)
        //            return new Response<string>($"Utilizador não encontrado");
        //        else
        //        {
        //            user.Email = dto.Email;
        //            user.IsActivo = dto.IsActivo.Value;
        //            user.UserName = dto.Username;

        //            var result = await _userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                return new Response<string>(null, message: $"Utilizador alterado com sucesso!");
        //            }
        //            else
        //            {
        //                throw new ApiException($"{result.Errors}");
        //            }
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        this._logger.Error(ex.Message);
        //        throw new ApiException(ex.Message);
        //    }
        //}
    }

}
