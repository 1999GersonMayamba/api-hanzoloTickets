using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public class DefaultComunaSeed
    {
        public static async Task SeedAsync(IComunaRepository comunaRepository)
        {

            var provincias = new List<Comuna>
            {
                new Comuna{Descricao = "Camama", IdComuna = Guid.Parse("58C1570F-C493-4B29-9174-4B3B0310EA3D"), IdMunicipio = Guid.Parse("510EB09C-7E67-49A4-B8AF-FF300BC0EE6D")},
                new Comuna{Descricao = "Cacuaco", IdComuna = Guid.Parse("40077398-29C5-49D1-99FD-1065ADD96495"), IdMunicipio = Guid.Parse("510EB09C-7E67-49A4-B8AF-FF300BC0EE6D")},
                new Comuna{Descricao = "Calumbo", IdComuna = Guid.Parse("9B794900-52FA-4B38-823C-2ADF8CAD63A6"), IdMunicipio = Guid.Parse("510EB09C-7E67-49A4-B8AF-FF300BC0EE6D")},
                new Comuna{Descricao = "Corimba", IdComuna = Guid.Parse("3B1A26CF-5FCC-479F-BD6C-AB72E0CA1F70"), IdMunicipio = Guid.Parse("510EB09C-7E67-49A4-B8AF-FF300BC0EE6D")},

            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in provincias)
            {
                var local = await comunaRepository.GetByGUIDAsync(x.IdComuna);
                if (local is null)
                    await comunaRepository.AddAsync(x);
            }

        }
    }
}
