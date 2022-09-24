using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class FiltroConsultaDTO
    {
        public Guid? IdEstado { get; set; }
        public DateTime? DataMin { get; set; }
        public DateTime? DataMax { get; set; }
        public Guid? IdEspecialidade { get; set; }
        public Guid? IdUnidade { get; set; }
        public string IdMedico { get; set; }
    }
}
