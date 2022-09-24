using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultMunicipioSeed
    {
        public static async Task SeedAsync(IMunicipioRepository municipioRepository)
        {

            var provincias = new List<Municipio>
            {
                new Municipio{Descricao = "Luanda", IdProvincia = Guid.Parse("353534BC-40A1-4615-958F-3ED2AE452556"), IdMunicipio = Guid.Parse("510EB09C-7E67-49A4-B8AF-FF300BC0EE6D")},
                new Municipio{Descricao = "Icolo e Bengo", IdProvincia = Guid.Parse("353534BC-40A1-4615-958F-3ED2AE452556"), IdMunicipio = Guid.Parse("009140E1-AB17-458C-A160-073937C10DC3")},
                new Municipio{Descricao = "Cacuaco", IdProvincia = Guid.Parse("353534BC-40A1-4615-958F-3ED2AE452556"), IdMunicipio = Guid.Parse("FECA0DD0-3C92-4F90-A4BB-2328CC38B844")},
                new Municipio{Descricao = "Talatona", IdProvincia = Guid.Parse("353534BC-40A1-4615-958F-3ED2AE452556"), IdMunicipio = Guid.Parse("077C0D04-B760-4185-A3B9-32FF98E51204")},

            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in provincias)
            {
                var local = await municipioRepository.GetByGUIDAsync(x.IdMunicipio);
                if (local is null)
                    await municipioRepository.AddAsync(x);
            }

        }
    }
}
