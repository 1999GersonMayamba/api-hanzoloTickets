using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ProjectoManutencaoPreventivaAddDTO
    {
        public Guid IdManutencao { get; set; }
        public Guid IdProjecto { get; set; }
        public string Cod { get; set; }
    }
}
