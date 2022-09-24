using Application.DTOs.Ficheiros;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Colaboradores
{
    public class NotaUtilizadorDTO
    {
        public Guid Id{ get; set; }
        public string IdUtilizador { get; set; }
        public DateTime DataCriacao { get; set; }

        public string ContentInBase64 { get; set; }
        public string Descricao { get; set; }

        public Guid IdAnexo { get; set; }

        public FicheiroDTO Anexo { get; set; }
    }
}
