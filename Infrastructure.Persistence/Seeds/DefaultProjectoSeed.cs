using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultProjectoSeed
    {
        public static async Task SeedAsync(IProjectoRepository projectoRepository)
        {

            var dominios = new List<Projecto>
            {
                new Projecto{Descricao = "Inspeção", IdProjecto = Guid.Parse("6D4DC5AC-89F5-4EEC-A3A9-420950273FC6")},
                new Projecto{Descricao = "Sistema CCTV", IdProjecto = Guid.Parse("5174E5A8-E6F8-414A-92FD-E2DFD82BC9B1")},
                new Projecto{Descricao = "Sistema de incêndio", IdProjecto = Guid.Parse("A48C48C8-DA59-475B-91E3-20D128FB61FF")},
                new Projecto{Descricao = "Sistema de intrusão", IdProjecto = Guid.Parse("9925B75B-0DF1-4446-8D5D-02085FF39A77")},
                new Projecto{Descricao = "Sistema de acesso", IdProjecto = Guid.Parse("BD3006DB-10C2-4291-98EB-0537A947F0CC")},
                new Projecto{Descricao = "Sistema de Saarf", IdProjecto = Guid.Parse("F9CF9CDE-6B98-4C22-8D38-A756845CBC56")}

            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await projectoRepository.GetByGUIDAsync(x.IdProjecto);
                if (local is null)
                    await projectoRepository.AddAsync(x);
            }

        }
    }
}
