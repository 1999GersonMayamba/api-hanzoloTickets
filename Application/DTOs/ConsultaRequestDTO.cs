using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ConsultaRequestDTO
    {
        public Guid IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string NConsulta { get; set; }
        public string Hora { get; set; }
        public string NumeroApolice { get; set; }
        public string NumeroSeguro { get; set; }
        public string IdMedico { get; set; }
        public virtual EspecialistasRequestDTO Medico { get; set; }
        public string BreveHistorial { get; set; }
        public string MotivoConsulta { get; set; }
        public string AntecedentesFamiliares { get; set; }
        public string AntecedentesPessoais { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public string MedicamentosIngeridos { get; set; }
        public string Sintomas { get; set; }
        public Guid? IdEstadoConsulta { get; set; }
        public virtual EstadoConsultaDTO EstadoConsulta { get; set; }
        public Guid IdCliente { get; set; }
        public virtual ClienteRequestDTO Cliente { get; set; }
        public Guid IdUnidade { get; set; }
        public virtual UnidadeDTO Unidade { get; set; }
        public Guid? IdPrioridade { get; set; }
        public virtual PrioridadeDTO Prioridade { get; set; }
        public Guid? IdSeguro { get; set; }
        public virtual SeguroDTO Seguro { get; set; }
        public Guid? IdEspecialidadeMedica { get; set; }
        public virtual EspecialidadeMedicaDTO EspecialidadeMedica { get; set; }
    }
}
