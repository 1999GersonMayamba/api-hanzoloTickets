using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultProvinciaSeed
    {
        public static async Task SeedAsync(IProvinciaRepository provinciaRepository)
        {

            var provincias = new List<Provincia>
            {
                new Provincia{Descricao = "Bengo", IdProvincia = Guid.Parse("63C2F5A0-543C-4C38-9BC9-E932D9DC118A")},
                new Provincia{Descricao = "Benguela", IdProvincia = Guid.Parse("3A444A50-739A-4B1A-BD9F-6B5EA88CEA24")},
                 new Provincia{Descricao = "Bié", IdProvincia = Guid.Parse("AAAB095F-10E7-409F-A71C-562F946225DF")},
                  new Provincia{Descricao = "Cabinda", IdProvincia = Guid.Parse("63096839-E813-48FD-8F49-97DEFD12C35E")},
                   new Provincia{Descricao = "Cuando-Cubango", IdProvincia = Guid.Parse("B7F61981-A65C-4C0C-91FE-A21C354F8837")},
                   new Provincia{Descricao = "Cunene", IdProvincia = Guid.Parse("00859F79-CDF0-463A-B004-BA986C978E66")},
                   new Provincia{Descricao = "Huambo", IdProvincia = Guid.Parse("8FC40136-A4D8-4699-A9B5-574BF2BF8785")},
                   new Provincia{Descricao = "Huíla", IdProvincia = Guid.Parse("97C7627B-B7A4-4305-8835-7EDCAD953091")},
                   new Provincia{Descricao = "Kwanza Sul", IdProvincia = Guid.Parse("9857586E-1206-4B95-BAA5-F5DAAC162105")},
                   new Provincia{Descricao = "Kwanza Norte", IdProvincia = Guid.Parse("50D8B5A5-82AC-4451-9ECB-EC4DD874B5A9")},
                   new Provincia{Descricao = "Luanda", IdProvincia = Guid.Parse("353534BC-40A1-4615-958F-3ED2AE452556")},
                   new Provincia{Descricao = "Lunda Norte", IdProvincia = Guid.Parse("FD8AB2F9-3D33-4FA4-A7BF-9093EB30A05E")},
                   new Provincia{Descricao = "Malanje", IdProvincia = Guid.Parse("D030680F-165B-4D81-BDCC-0E2B3DAB5611")},
                   new Provincia{Descricao = "Moxico", IdProvincia = Guid.Parse("BB295874-DA56-4C22-8615-955A372283DE")},
                   new Provincia{Descricao = "Namibe", IdProvincia = Guid.Parse("AE0FA692-F8CD-4A1B-9EAD-48D51EA101F2")},
                   new Provincia{Descricao = "Uíge", IdProvincia = Guid.Parse("0CB3AE61-7E6A-4923-AC75-369800B452A8")},
                   new Provincia{Descricao = "Zaire", IdProvincia = Guid.Parse("9DC612A4-5E65-4DF6-815C-A8B11E435F42")},
            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in provincias)
            {
                var local = await provinciaRepository.GetByGUIDAsync(x.IdProvincia);
                if (local is null)
                    await provinciaRepository.AddAsync(x);
            }

        }
    }
}
