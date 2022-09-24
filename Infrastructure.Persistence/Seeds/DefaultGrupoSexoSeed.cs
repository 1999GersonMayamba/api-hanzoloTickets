using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static  class DefaultGrupoSexoSeed
    {
        public static async Task SeedAsync(IGrupoSexoRepository grupoSexoRepository)
        {

            var provincias = new List<GrupoSexo>
            {
                new GrupoSexo{Descricao = "Masculino", IdGrupoSexo = Guid.Parse("E9BD8477-89A3-463A-9A84-6FE0610C272B")},
                new GrupoSexo{Descricao = "Feminino", IdGrupoSexo = Guid.Parse("A17174A9-5DC2-4B06-86FC-E6A45BC1938B")}
            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in provincias)
            {
                var local = await grupoSexoRepository.GetByGUIDAsync(x.IdGrupoSexo);
                if (local is null)
                    await grupoSexoRepository.AddAsync(x);
            }

        }
    }
}
