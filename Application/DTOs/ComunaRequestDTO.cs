using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ComunaRequestDTO
    {
        public Guid IdComuna { get; set; }
        public string Descricao { get; set; }
        public MunicipioRequestDTO Municipio { get; set; }
    }
}
