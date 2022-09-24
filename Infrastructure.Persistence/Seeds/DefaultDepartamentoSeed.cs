using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public class DefaultDepartamentoSeed
    {
        public static async Task SeedAsync(IDepartamentoRepository departamentoRepository)
        {

            var dominios = new List<Departamento>
            {
                new Departamento{Descricao = "N/A", IdDepartamento = Guid.Parse("5DF2ADAE-8B7D-4223-1AD2-08DA0A7628F8")},
                new Departamento{Descricao = "Finanças", IdDepartamento = Guid.Parse("E5AC2547-8E8E-4304-8AA6-0E27F475CEBF")},
                new Departamento{Descricao = "Informática", IdDepartamento = Guid.Parse("9A458C58-DF2E-4795-AEDC-45C064542323")},
                new Departamento{Descricao = "Médicos", IdDepartamento = Guid.Parse("F63A5495-20AA-4902-8973-501583D083C7")},
                new Departamento{Descricao = "Administrativo", IdDepartamento = Guid.Parse("B84308C8-4716-4390-A043-A085B61D8378")},
                new Departamento{Descricao = "RH", IdDepartamento = Guid.Parse("35A654B5-3060-4C88-BEB2-E3BA593D0561")},



            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await departamentoRepository.GetByGUIDAsync(x.IdDepartamento);
                if (local is null)
                    await departamentoRepository.AddAsync(x);
            }

        }
    }
}
