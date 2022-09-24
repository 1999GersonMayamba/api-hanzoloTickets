using Application.DTOs;
using Application.DTOs.Colaboradores;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface INotaUtilizadorService
    {
        Task<Response<Guid>> RegisterAsync(NotaUtilizadorDTO notaDto);
        Task<Response<Guid>> RemoveAsync(Guid id);
        Task<Response<List<NotaUtilizadorDTO>>> GetByIdUser(string idUser);
        //Task<Response<Guid>> ExelFileToReportFile(ExelFileToReportFileDTO File);
    }
}
