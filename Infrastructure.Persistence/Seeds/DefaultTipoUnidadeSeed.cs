using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public class DefaultTipoUnidadeSeed
    {
        public static async Task SeedAsync(ITipoUnidadeRepository tipoUnidadeRepository)
        {

            var dominios = new List<TipoUnidade>
            {
                new TipoUnidade{Descricao = "N/A", IdTipoUnidade = Guid.Parse("861C1549-ECF3-43E9-A8AC-7B098296C272")},
                new TipoUnidade{Descricao = "Agências", IdTipoUnidade = Guid.Parse("AC815B33-47BD-407E-8AE2-FE352DB1D557")},
                new TipoUnidade{Descricao = "CAE", IdTipoUnidade = Guid.Parse("1F381B10-3AB8-4C22-8258-56E60D532106")},
                new TipoUnidade{Descricao = "Dependência", IdTipoUnidade = Guid.Parse("7A309B8A-2927-406C-ACAA-B198AE8ECCF9")},
                new TipoUnidade{Descricao = "Posto de atendimento", IdTipoUnidade = Guid.Parse("B2F58F11-8A9F-443D-AF19-3357D55182A7")},
                new TipoUnidade{Descricao = "Serviços premium", IdTipoUnidade = Guid.Parse("9B5A8498-B266-4E03-88E1-E6D840360102")},



            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await tipoUnidadeRepository.GetByGUIDAsync(x.IdTipoUnidade);
                if (local is null)
                    await tipoUnidadeRepository.AddAsync(x);
            }

        }
    }
}
