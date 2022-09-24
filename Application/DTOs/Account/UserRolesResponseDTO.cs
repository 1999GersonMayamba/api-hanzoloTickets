using Application.DTOs.Permissoes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account
{
   public class UserRolesResponseDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        //public DominioDTO Dominio { get; set; }
        //public List<PermissoesUtilizadoresDTO> Permissoes { get; set; }
        public List<IdentityRoleDTO> Roles { get; set; }
        public DominioDTO Dominio { get; set; }
        public List<UnidadeUserDTO> Unidades { get; set; }

    }
}
