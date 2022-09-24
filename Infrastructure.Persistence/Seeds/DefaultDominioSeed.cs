using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultDominioSeed
    {
        public static async Task SeedAsync(IDominioRepository dominioRepository)
        {

            var dominios = new List<Dominio>
            {
                //new Dominio{Descricao = "Endiama", IdDominio = Guid.Parse("5D2D04DC-337B-4331-97EB-C6DC6169A8A2"), Url = "00E1"},
                //new Dominio{Descricao = "Vita", IdDominio = Guid.Parse("7DF066FA-4BBC-4059-A9C6-70FD1C57D704"), Url = "00V1"},
                //new Dominio{Descricao = "Luanda Medical Center", IdDominio = Guid.Parse("215715FD-F76C-46D5-8DE1-34447B36240D"), Url = "00A1"},
                //new Dominio{Descricao = "Josina Machel", IdDominio = Guid.Parse("285157C3-2488-4F1F-B910-20D8485FFCF0"), Url = "00J1"},
                //new Dominio{Descricao = "Castelo", IdDominio = Guid.Parse("117B2BE8-F2C6-492D-BC7C-6C163B335A30"), Url = "00C1"},
                new Dominio{Descricao = "BAI", IdDominio = Guid.Parse("833779D2-35A1-49F0-B989-17B328CA834A"), Url = "00C1"}


            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await dominioRepository.GetByGUIDAsync(x.IdDominio);
                if (local is null)
                    await dominioRepository.AddAsync(x);
            }

        }
    }
}
