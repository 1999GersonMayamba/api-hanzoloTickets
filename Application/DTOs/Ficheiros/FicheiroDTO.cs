using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Ficheiros
{
    public class FicheiroDTO
    {
      
        public Guid IdAnexo { get; set; }
        public byte[] Content { get; set; }

        public int? IdTipoFicheiro { get; set; }

      
        public TipoFicheiroDTO TipoFicheiro { get; set; }


        public string MimeType { get; set; }

        public string Path { get; set; }

        public string Nome { get; set; }
    }
}
