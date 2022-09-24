using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultOrigemManutencaoSeed
    {
        public static async Task SeedAsync(IOrigemManutencaoRepository origemManutencaoRepository)
        {

            var dominios = new List<OrigemManutencao>
            {
                new OrigemManutencao{Descricao = "Manutenção Preventiva", IdOrigemManutencao = Guid.Parse("38D087EB-D70D-4582-8BA9-1501366A098C")},
                new OrigemManutencao{Descricao = "Intervenção Técnica", IdOrigemManutencao = Guid.Parse("2CBD16CD-0A56-482D-AA42-CFDA738AC9A6")}

            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await origemManutencaoRepository.GetByGUIDAsync(x.IdOrigemManutencao);
                if (local is null)
                    await origemManutencaoRepository.AddAsync(x);
            }

        }
    }
}
