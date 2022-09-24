using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultEstadoManuntencaoSeed
    {
        public static async Task SeedAsync(IEstadoManutencaoRepository estadoManutencaoRepository)
        {

            var dominios = new List<EstadoManutencao>
            {
                new EstadoManutencao{Descricao = "Pendente", IdEstadoManutencao = Guid.Parse("61599B43-498C-4404-BC6E-902956CD54D7")},
                new EstadoManutencao{Descricao = "Fechada", IdEstadoManutencao = Guid.Parse("C1BD0525-0FA5-4F39-96F1-638347386CBB")},
                new EstadoManutencao{Descricao = "Em curso", IdEstadoManutencao = Guid.Parse("16685CC4-C2AB-4ADB-AE77-DB2FAEE8D53A")},
                new EstadoManutencao{Descricao = "Criada", IdEstadoManutencao = Guid.Parse("60D7E6B7-63AF-4885-FB0A-08DA3059B75E")},
                new EstadoManutencao{Descricao = "Aberta", IdEstadoManutencao = Guid.Parse("F5852A76-E041-41D9-FB0B-08DA3059B75E")}
               
                //new EstadoManutencao{Descricao = "Anulada", IdEstadoManutencao = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")}



            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await estadoManutencaoRepository.GetByGUIDAsync(x.IdEstadoManutencao);
                if (local is null)
                    await estadoManutencaoRepository.AddAsync(x);
            }

        }
    }
}
