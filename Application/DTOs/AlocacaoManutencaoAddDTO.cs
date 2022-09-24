using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class AlocacaoManutencaoAddDTO
    {
        public Guid IdManutencao { get; set; }
        public string Id { get; set; }
        public DateTime DataRegisto { get; set; }  =  DateTime.Now;
        public DateTime DataManutencao { get; set; } = DateTime.Now;
    }
}
