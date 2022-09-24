using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultPrestadorSeed
    {
        public static async Task SeedAsync(IPrestadorRepository prestadorRepository)
        {

            var prestadors = new List<Prestador>
            {
                //Adicionar Unidades do banco BAI
                new Prestador{Descricao = "Tencologia sistemas e segurança", Nome = "Hanzolo", Endereco = "Via de Viana-Talatona-Rotunda da Camama LUANDA", IdMunicipio = Guid.Parse("077C0D04-B760-4185-A3B9-32FF98E51204"), IdPrestador = Guid.Parse("008A90EA-E574-4BA8-BADF-E74284042563"), Telefone = "+244-996-749-753" },
                new Prestador{Descricao = "NG consultoria e sistemas", Nome = "NG", Endereco = "Av.11 de Novembro-Lg. da Adm. de Viana LUANDA", IdMunicipio = Guid.Parse("077C0D04-B760-4185-A3B9-32FF98E51204"), IdPrestador = Guid.Parse("DFA770B3-BB8B-4A46-8C74-9404350E3DB2"), Telefone = "+244-996-749-753"}
            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in prestadors)
            {
                var local = await prestadorRepository.GetByGUIDAsync(x.IdPrestador);
                if (local is null)
                    await prestadorRepository.AddAsync(x);
            }

        }
    }
}
