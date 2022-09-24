using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class SubFamiliaRequestDTO
    {
        public Guid IdSubFamilia { get; set; }
        public string Decricao { get; set; }
        public Guid IdFamilia { get; set; }
        public FamiliaDTO Familia { get; set; }
    }
}
