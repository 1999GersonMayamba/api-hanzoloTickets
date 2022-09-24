using Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class AlocacaoManutencaoRequestDTO
    {
		public Guid IdAlocacaoManutencao { get; set; }
		public DateTime DataRegisto { get; set; }
		public DateTime DataManutencao { get; set; }
		public Guid IdManutencao { get; set; }
		public string IdUser { get; set; }
        public UserResponseDTO User { get; set; }
    }
}
