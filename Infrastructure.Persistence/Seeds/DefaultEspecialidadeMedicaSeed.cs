using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public class DefaultEspecialidadeMedicaSeed
    {
        public static async Task SeedAsync(IEspecialidadeMedicaRepository especialidadeMedicaRepository)
        {

            var dominios = new List<EspecialidadeMedica>
            {
                new EspecialidadeMedica{Descricao = "Estomatologia", IdEspecialidadeMedica = Guid.Parse("8CFCA5DB-E84D-4331-A69C-046B138128D3"), IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885"), IdDepartamento = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")},
                new EspecialidadeMedica{Descricao = "Pediatria", IdEspecialidadeMedica = Guid.Parse("46F48E2C-A085-477D-A66D-15E311DE1AB3"), IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885"), IdDepartamento = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")},
                new EspecialidadeMedica{Descricao = "Clínico Geral ", IdEspecialidadeMedica = Guid.Parse("2F9F9D51-DA50-4531-A326-1C365CA1790E"), IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885"), IdDepartamento = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")},
                new EspecialidadeMedica{Descricao = "Radiologia", IdEspecialidadeMedica = Guid.Parse("EDC992BE-B4D7-4795-9A96-2580C0615F96"), IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885"), IdDepartamento = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")},
                new EspecialidadeMedica{Descricao = "Pré-Natal", IdEspecialidadeMedica = Guid.Parse("E4AE859F-0BE5-4789-9F45-28DF18444C05"), IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885"), IdDepartamento = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")},
                 new EspecialidadeMedica{Descricao = "N/A", IdEspecialidadeMedica = Guid.Parse("F323C13C-BB6A-40AE-9034-C29C3D82F726"), IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885"), IdDepartamento = Guid.Parse("5DF2ADAE-8B7D-4223-1AD2-08DA0A7628F8")}

            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await especialidadeMedicaRepository.GetByGUIDAsync(x.IdEspecialidadeMedica);
                if (local is null)
                    await especialidadeMedicaRepository.AddAsync(x);
            }

        }
    }
}
