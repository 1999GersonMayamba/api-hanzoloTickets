//using Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Identity.Entities
{

    [Table("User", Schema = "Identity")]
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public List<RefreshToken> RefreshTokens { get; set; }
        //public bool OwnsToken(string token)
        //{
        //    //return this.RefreshTokens?.Find(x => x.Token == token) != null;
        //}

        public virtual ICollection<PermissaoUtilizador> Permissoes { get; set; }

        /// <summary>
        /// Id tipo de utilizador, atributo chave estrangeira
        /// </summary>
        public int? IdTipoUtilizador { get; set; }

        public bool IsActivo { get; set; }
        /// <summary>
        /// Tipo de utilizador(Chave estrangeira)
        /// </summary>
        [ForeignKey("IdTipoUtilizador")]
        public TipoUtilizador TipoUtilizador { get; set; }

        //public virtual ICollection<Inquerito> Inqueritos { get; set; }
        //public virtual ICollection<Link> Links { get; set; }
        public string Nome { get; set; }
        public string PeerID { get; set; }

        /// <summary>
        /// Id de dominio para dizer em que dominio o Utilizador pertence
        /// </summary>
        public Guid? IdDominio { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }
}
