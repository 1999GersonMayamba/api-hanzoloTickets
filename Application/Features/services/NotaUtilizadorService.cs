using Application.DTOs;
using Application.DTOs.Colaboradores;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.NLog;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.services
{
    public class NotaUtilizadorService : INotaUtilizadorService
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly INotaUtilizadorRepository _notaRepository;
        private ILog _logger;
        public NotaUtilizadorService(INotaUtilizadorRepository notaRepository, IMapper mapper, ILog logger, IFileService fileService)
        {
            _mapper = mapper;
            this._notaRepository = notaRepository;
            this._logger = logger;
            this._fileService = fileService;
        }

        public async Task<Response<List<NotaUtilizadorDTO>>> GetByIdUser(string idUser)
        {
            try
            {
                return new Response<List<NotaUtilizadorDTO>>
               (_mapper.Map<List<NotaUtilizadorDTO>>(await this._notaRepository.GetByIdUser(idUser)), $"List of notes by user");
            }
            catch (System.Exception ex)
            {
                this._logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }
        public async Task<Response<Guid>> RegisterAsync(NotaUtilizadorDTO request)
        {
            try
            {
                request.DataCriacao = DateTime.Now;
                request.Id = Guid.NewGuid();
                string nomePasta = Constantes.Constantes.FullPathFilesPublicacoes1 + "\\" + Constantes.Constantes.PathFolderPublicacoes + "\\" + request.Id;
                if (await this._fileService.CriarPasta(nomePasta))
                {
                    string path = Path.Combine(nomePasta, request.Anexo.Nome);
                    if (await this._fileService.ConterBase64TOFile(path, request.ContentInBase64))
                    {
                        request.Anexo.IdAnexo = Guid.NewGuid();
                        request.Anexo.Path =  Constantes.Constantes.PathFolderPublicacoes + "//" + request.Id + "//" + request.Anexo.Nome;

                    }
                }

                var result = _mapper.Map<NotaUtilizador>(request);
                await _notaRepository.AddAsync(result);
                return new Response<Guid>(result.Id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this._logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<Guid>> RemoveAsync(Guid id)
        {
            try
            {
                await _notaRepository.DeleteAsync(await this._notaRepository.GetByGUIDAsync(id));
                return new Response<Guid>(id,Constantes.Constantes.RegistoEliminado);
            }
            catch (System.Exception ex)
            {
                this._logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }


	



		/// <summary>
		/// Validar o ficheiro
		/// </summary>
		/// <param name="inputfile"></param>
		/// <param name="fileStream"></param>
		/// <returns></returns>
		private bool ValidarFicheiro(Stream fileStream)
		{
			if (fileStream != null)
				return true;
			return false;
		}

	}
}
