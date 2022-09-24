using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultZonaSeed
    {
        public static async Task SeedAsync(IZonaRepository zonaRepository)
        {

            var dominios = new List<Zona>
            {
                new Zona{Descricao = "Norte", IdZona = Guid.Parse("833779D2-35A1-49F0-B989-17B328CA834A")},
                new Zona{Descricao = "Sul", IdZona = Guid.Parse("E6786BB2-8573-4FBC-8800-13DD00096203")}
            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await zonaRepository.GetByGUIDAsync(x.IdZona);
                if (local is null)
                    await zonaRepository.AddAsync(x);
            }

        }
    }
}
