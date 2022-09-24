using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
   public static class DefaultUnidadeSeed
    {
        public static async Task SeedAsync(IUnidadeRepository unidadeRepository)
        {

            var dominios = new List<Unidade>
            {
                //new Unidade{Descricao = "Mazuika King", Nome = "00E100", Endereco = "Rua 342", IdDominio = Guid.Parse("5D2D04DC-337B-4331-97EB-C6DC6169A8A2"), IdMunicipio = Guid.Parse("077C0D04-B760-4185-A3B9-32FF98E51204"), Nif = "987968576", IdUnidade = Guid.Parse("C9BC879E-7A76-46BA-9713-46B03446A885")},
                //new Unidade{Descricao = "Bita Tanque", Nome = "00E101", Endereco = "Via do Kilamba Q 12",IdDominio = Guid.Parse("5D2D04DC-337B-4331-97EB-C6DC6169A8A2"), IdMunicipio = Guid.Parse("077C0D04-B760-4185-A3B9-32FF98E51204"), Nif = "987968576", IdUnidade = Guid.Parse("261DBD2A-743E-4AEF-BCD2-F31750860EC2")},



                //Adicionar Unidades do banco BAI
                new Unidade{Descricao = "DEPENDENCIA CAMAMA (0523)", Nome = "DEPENDENCIA CAMAMA (0523)", Endereco = "Via de Viana-Talatona-Rotunda da Camama LUANDA",IdDominio = Guid.Parse("833779D2-35A1-49F0-B989-17B328CA834A"), IdUnidade = Guid.Parse("FCF5A34F-9939-4346-85B2-58D101517DBC"), IdComuna = Guid.Parse("58C1570F-C493-4B29-9174-4B3B0310EA3D"), IdTipoUnidade = Guid.Parse("7A309B8A-2927-406C-ACAA-B198AE8ECCF9"), CodAgencia = "0001", Telefone1 = "222 370 661"},
                new Unidade{Descricao = "DEPENDENCIA VIANA (0524)", Nome = "DEPENDENCIA VIANA (0524)", Endereco = "Av.11 de Novembro-Lg. da Adm. de Viana LUANDA",IdDominio = Guid.Parse("833779D2-35A1-49F0-B989-17B328CA834A"), IdUnidade = Guid.Parse("9FF37410-FC74-49FA-9AC1-D97B62093372"), IdComuna = Guid.Parse("58C1570F-C493-4B29-9174-4B3B0310EA3D"), IdTipoUnidade = Guid.Parse("7A309B8A-2927-406C-ACAA-B198AE8ECCF9"), CodAgencia = "0002", Telefone1 = "222 370 662"},
                new Unidade{Descricao = "DEPENDENCIA CACUACO (0525)", Nome = "DEPENDENCIA CACUACO (0525)", Endereco = "Rua Direita de Cacuaco, S/N LUANDA",IdDominio = Guid.Parse("833779D2-35A1-49F0-B989-17B328CA834A"), IdUnidade = Guid.Parse("80F02EB7-E6AC-455C-88E2-2BDAD4AF05DA"), IdComuna = Guid.Parse("58C1570F-C493-4B29-9174-4B3B0310EA3D"), IdTipoUnidade = Guid.Parse("7A309B8A-2927-406C-ACAA-B198AE8ECCF9"), CodAgencia = "0003", Telefone1 = "222 370 663"}
            };


            //Validar se os  GrupoCliente já se encontra na BD
            foreach (var x in dominios)
            {
                var local = await unidadeRepository.GetByGUIDAsync(x.IdUnidade);
                if (local is null)
                    await unidadeRepository.AddAsync(x);
            }

        }
    }
}
