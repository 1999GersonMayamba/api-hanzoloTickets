using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class MunicipioRequestDTO
    {
        public Guid IdMunicipio { get; set; }
        public Guid IdProvincia { get; set; }
        public string Descricao { get; set; }
        public ProvinciaDTO Provincia { get; set; }
    }
}
