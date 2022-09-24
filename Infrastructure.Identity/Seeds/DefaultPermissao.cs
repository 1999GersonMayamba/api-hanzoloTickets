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
   public static class DefaultPermissao
    {
        public static async Task SeedAsync(IPermissoesService permissoesService)
        {
            //Seed Default Permissão
            var defautPermissao = new PermissoesDTO
            {
                IdPermissao = 1,
                IdGrupoPermissao = 1,
                Nome = "Inserir"
            };


            var Permissao = await permissoesService.GetById(defautPermissao.IdPermissao);

            //Verificar se a permissão já existe ?
            if (Permissao.Data == null)
            {
                //Registar o grupo de permissão
                await permissoesService.RegisterAsync(defautPermissao);
            }
        }
    }
}
