using Application.DTOs.Permissoes;
using Application.Features.services;
using Application.Interfaces.Services.Permissoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
   public static class DefaultGrupoUtilizador
    {
        public static async Task SeedAsync(IGruposPermissoesService gruposPermissoesService)
        {
            //Seed Default GrupoUtilizador
            var defautGrupoPermissao = new GruposPermissoesDTO
            {
                IdGrupoPermissao = 1,
                Nome = "Gestão de utilizador"
            };


            var grupoPermissao = await gruposPermissoesService.GetById(defautGrupoPermissao.IdGrupoPermissao);

            //Verificar se o grupo já existe ?
            if (grupoPermissao.Data == null)
            {
                //Registar o grupo de permissão
                await gruposPermissoesService.RegisterAsync(defautGrupoPermissao);
            }
        }
    }
}
