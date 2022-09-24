using Application.DTOs.Colaboradores;
using Application.DTOs.Permissoes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Application.DTOs.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Roles { get; set; }
        public List<PermissoesUtilizadoresDTO> Permissoes { get; set; }
        public bool IsVerified { get; set; }
        public string JWToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }

        public string PeerdID { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public DominioDTO Dominio { get; set; }
        public List<UnidadeUserDTO> Unidades { get; set; }
        public List<PrestadorUtilizadorAddDTO> Prestadores { get; set; }
    }
}
