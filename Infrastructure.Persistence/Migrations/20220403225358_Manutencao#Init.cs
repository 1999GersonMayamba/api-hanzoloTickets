using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ManutencaoInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "EstadoManutencao",
                columns: table => new
                {
                    IdEstadoManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoManutencao", x => x.IdEstadoManutencao);
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    IdFamilia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.IdFamilia);
                });

            migrationBuilder.CreateTable(
                name: "GrupoSexo",
                columns: table => new
                {
                    IdGrupoSexo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoSexo", x => x.IdGrupoSexo);
                });

            //migrationBuilder.CreateTable(
            //    name: "GruposPermissoes",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        IdGrupoPermissao = table.Column<int>(type: "int", nullable: false),
            //        Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_GruposPermissoes", x => x.IdGrupoPermissao);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notas",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        IdUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Created = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notas", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "OrigemManutencao",
                columns: table => new
                {
                    IdOrigemManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigemManutencao", x => x.IdOrigemManutencao);
                });

            migrationBuilder.CreateTable(
                name: "Prioridade",
                columns: table => new
                {
                    IdPrioridade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridade", x => x.IdPrioridade);
                });

            migrationBuilder.CreateTable(
                name: "Projecto",
                columns: table => new
                {
                    IdProjecto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projecto", x => x.IdProjecto);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    IdProvincia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.IdProvincia);
                });

            migrationBuilder.CreateTable(
                name: "TipoDominio",
                columns: table => new
                {
                    IdTipoDominio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDominio", x => x.IdTipoDominio);
                });

            //migrationBuilder.CreateTable(
            //    name: "TipoUtilizador",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        IdTipoUtilizador = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoUtilizador", x => x.IdTipoUtilizador);
            //    });

            migrationBuilder.CreateTable(
                name: "SubFamilia",
                columns: table => new
                {
                    IdSubFamilia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Decricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFamilia = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFamilia", x => x.IdSubFamilia);
                    table.ForeignKey(
                        name: "FK_SubFamilia_Familia_IdFamilia",
                        column: x => x.IdFamilia,
                        principalTable: "Familia",
                        principalColumn: "IdFamilia",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Permissoes",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        IdPermissao = table.Column<int>(type: "int", nullable: false),
            //        Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdGrupoPermissao = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Permissoes", x => x.IdPermissao);
            //        table.ForeignKey(
            //            name: "FK_Permissoes_GruposPermissoes_IdGrupoPermissao",
            //            column: x => x.IdGrupoPermissao,
            //            principalSchema: "Identity",
            //            principalTable: "GruposPermissoes",
            //            principalColumn: "IdGrupoPermissao",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    IdMunicipio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProvincia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.IdMunicipio);
                    table.ForeignKey(
                        name: "FK_Municipio_Provincia_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincia",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dominio",
                columns: table => new
                {
                    IdDominio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoDominio = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominio", x => x.IdDominio);
                    table.ForeignKey(
                        name: "FK_Dominio_TipoDominio_IdTipoDominio",
                        column: x => x.IdTipoDominio,
                        principalTable: "TipoDominio",
                        principalColumn: "IdTipoDominio",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdTipoUtilizador = table.Column<int>(type: "int", nullable: true),
            //        IsActivo = table.Column<bool>(type: "bit", nullable: false),
            //        Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PeerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IdDominio = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_User_TipoUtilizador_IdTipoUtilizador",
            //            column: x => x.IdTipoUtilizador,
            //            principalSchema: "Identity",
            //            principalTable: "TipoUtilizador",
            //            principalColumn: "IdTipoUtilizador",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSubFamilia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProjecto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamento_Projecto_IdProjecto",
                        column: x => x.IdProjecto,
                        principalTable: "Projecto",
                        principalColumn: "IdProjecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_SubFamilia_IdSubFamilia",
                        column: x => x.IdSubFamilia,
                        principalTable: "SubFamilia",
                        principalColumn: "IdSubFamilia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    IdUnidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMunicipio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDominio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.IdUnidade);
                    table.ForeignKey(
                        name: "FK_Unidade_Dominio_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominio",
                        principalColumn: "IdDominio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidade_Municipio_IdMunicipio",
                        column: x => x.IdMunicipio,
                        principalTable: "Municipio",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "PermissoesUtilizadores",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        IdPermissaoUtilizador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        IdPermissao = table.Column<int>(type: "int", nullable: false),
            //        IdUtilizador = table.Column<string>(type: "nvarchar(450)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PermissoesUtilizadores", x => x.IdPermissaoUtilizador);
            //        table.ForeignKey(
            //            name: "FK_PermissoesUtilizadores_Permissoes_IdPermissao",
            //            column: x => x.IdPermissao,
            //            principalSchema: "Identity",
            //            principalTable: "Permissoes",
            //            principalColumn: "IdPermissao",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PermissoesUtilizadores_User_IdUtilizador",
            //            column: x => x.IdUtilizador,
            //            principalSchema: "Identity",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "EspecialidadeMedica",
                columns: table => new
                {
                    IdEspecialidadeMedica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDepartamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeMedica", x => x.IdEspecialidadeMedica);
                    table.ForeignKey(
                        name: "FK_EspecialidadeMedica_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeMedica_Unidade_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidade",
                        principalColumn: "IdUnidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    IdManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataResolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstadoManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUnidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.IdManutencao);
                    table.ForeignKey(
                        name: "FK_Manutencao_EstadoManutencao_IdEstadoManutencao",
                        column: x => x.IdEstadoManutencao,
                        principalTable: "EstadoManutencao",
                        principalColumn: "IdEstadoManutencao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manutencao_Unidade_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidade",
                        principalColumn: "IdUnidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manutencao_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeUtilizador",
                columns: table => new
                {
                    IdUnidadeUtilizador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdUnidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEspecialidadeMedica = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeUtilizador", x => x.IdUnidadeUtilizador);
                    table.ForeignKey(
                        name: "FK_UnidadeUtilizador_EspecialidadeMedica_IdEspecialidadeMedica",
                        column: x => x.IdEspecialidadeMedica,
                        principalTable: "EspecialidadeMedica",
                        principalColumn: "IdEspecialidadeMedica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnidadeUtilizador_Unidade_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidade",
                        principalColumn: "IdUnidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadeUtilizador_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectoManutencao",
                columns: table => new
                {
                    IdProjectoManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProjecto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectoManutencao", x => x.IdProjectoManutencao);
                    table.ForeignKey(
                        name: "FK_ProjectoManutencao_Manutencao_IdManutencao",
                        column: x => x.IdManutencao,
                        principalTable: "Manutencao",
                        principalColumn: "IdManutencao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectoManutencao_Projecto_IdProjecto",
                        column: x => x.IdProjecto,
                        principalTable: "Projecto",
                        principalColumn: "IdProjecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dominio_IdTipoDominio",
                table: "Dominio",
                column: "IdTipoDominio");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_IdProjecto",
                table: "Equipamento",
                column: "IdProjecto");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_IdSubFamilia",
                table: "Equipamento",
                column: "IdSubFamilia");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeMedica_IdDepartamento",
                table: "EspecialidadeMedica",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeMedica_IdUnidade",
                table: "EspecialidadeMedica",
                column: "IdUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdEstadoManutencao",
                table: "Manutencao",
                column: "IdEstadoManutencao");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdUnidade",
                table: "Manutencao",
                column: "IdUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdUser",
                table: "Manutencao",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_IdProvincia",
                table: "Municipio",
                column: "IdProvincia");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Permissoes_IdGrupoPermissao",
            //    schema: "Identity",
            //    table: "Permissoes",
            //    column: "IdGrupoPermissao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PermissoesUtilizadores_IdPermissao",
            //    schema: "Identity",
            //    table: "PermissoesUtilizadores",
            //    column: "IdPermissao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PermissoesUtilizadores_IdUtilizador",
            //    schema: "Identity",
            //    table: "PermissoesUtilizadores",
            //    column: "IdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectoManutencao_IdManutencao",
                table: "ProjectoManutencao",
                column: "IdManutencao");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectoManutencao_IdProjecto",
                table: "ProjectoManutencao",
                column: "IdProjecto");

            migrationBuilder.CreateIndex(
                name: "IX_SubFamilia_IdFamilia",
                table: "SubFamilia",
                column: "IdFamilia");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdDominio",
                table: "Unidade",
                column: "IdDominio");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdMunicipio",
                table: "Unidade",
                column: "IdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeUtilizador_IdEspecialidadeMedica",
                table: "UnidadeUtilizador",
                column: "IdEspecialidadeMedica");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeUtilizador_IdUnidade",
                table: "UnidadeUtilizador",
                column: "IdUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeUtilizador_IdUser",
                table: "UnidadeUtilizador",
                column: "IdUser");

            //migrationBuilder.CreateIndex(
            //    name: "IX_User_IdTipoUtilizador",
            //    schema: "Identity",
            //    table: "User",
            //    column: "IdTipoUtilizador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "GrupoSexo");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "OrigemManutencao");

            //migrationBuilder.DropTable(
            //    name: "PermissoesUtilizadores",
            //    schema: "Identity");

            migrationBuilder.DropTable(
                name: "Prioridade");

            migrationBuilder.DropTable(
                name: "ProjectoManutencao");

            migrationBuilder.DropTable(
                name: "UnidadeUtilizador");

            migrationBuilder.DropTable(
                name: "SubFamilia");

            //migrationBuilder.DropTable(
            //    name: "Permissoes",
            //    schema: "Identity");

            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.DropTable(
                name: "Projecto");

            migrationBuilder.DropTable(
                name: "EspecialidadeMedica");

            migrationBuilder.DropTable(
                name: "Familia");

            //migrationBuilder.DropTable(
            //    name: "GruposPermissoes",
            //    schema: "Identity");

            migrationBuilder.DropTable(
                name: "EstadoManutencao");

            //migrationBuilder.DropTable(
            //    name: "User",
            //    schema: "Identity");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Unidade");

            //migrationBuilder.DropTable(
            //    name: "TipoUtilizador",
            //    schema: "Identity");

            migrationBuilder.DropTable(
                name: "Dominio");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "TipoDominio");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
