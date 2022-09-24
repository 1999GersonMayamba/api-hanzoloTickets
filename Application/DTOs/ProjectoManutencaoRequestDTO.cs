using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ProjectoManutencaoRequestDTO
    {
        public Guid IdProjectoManutencao { get; set; }
        public Guid IdManutencao { get; set; }
        public Guid IdProjecto { get; set; }
        public ProjectoDTO Projecto { get; set; }
    }
}
