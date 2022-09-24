using Application.DTOs.Colaboradores;
using Application.DTOs.Permissoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account
{
    public class UserResponseDTO
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Id { get; set; }

        public bool IsActivo { get; set; }
        public string UserName { get; set; }
        public ColaboradorDTO Colaborador { get; set; }

        public string PeerdID { get; set; }

        public List<string> Roles { get; set; }

        public List<PermissoesUtilizadoresDTO> Permissoes { get; set; }
        public string Nome { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }
}
