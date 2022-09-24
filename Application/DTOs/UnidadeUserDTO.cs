using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class UnidadeUserDTO
    {
        public Guid IdUnidade { get; set; }
        public Guid IdUnidadeUtilizador { get; set; }
        public string  Descricao { get; set; }
    }
}
