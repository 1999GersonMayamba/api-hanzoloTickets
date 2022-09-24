using Application.DTOs.Permissoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account
{
   public class RolesPermissionsUpdateDTO
    {
        public Guid IdUser { get; set; }

        public List<string> Roles { get; set; }
        public List<PermissoesDTO> Permissoes { get; set; }
    }
}
