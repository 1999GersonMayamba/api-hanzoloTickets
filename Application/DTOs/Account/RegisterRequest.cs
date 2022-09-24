using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs.Account
{
    public class RegisterRequest
    {
        //[Required]
        public string FirstName { get; set; }

        //[Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public int? IdTipoUtilizador { get; set; }

        public string Nome { get; set; }

        public List<string> Roles { get; set; }

        public Guid? IdDominio { get; set; }
    }
}
