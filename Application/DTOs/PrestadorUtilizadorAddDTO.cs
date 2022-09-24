using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
  public  class PrestadorUtilizadorAddDTO
    {
        public Guid IdPrestadorUtilizador { get; set; }
        public string IdUser { get; set; }
        public Guid? IdEspecialidadeMedica { get; set; }
        public Guid IdPrestador { get; set; }
        public PrestadorDTO Prestador { get; set; }
    }
}
