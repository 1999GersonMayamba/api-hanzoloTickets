using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ManutencaoRedePrestadotres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    IdPrestador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMunicipio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.IdPrestador);
                    table.ForeignKey(
                        name: "FK_Prestador_Municipio_IdMunicipio",
                        column: x => x.IdMunicipio,
                        principalTable: "Municipio",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrestadorUtilizador",
                columns: table => new
                {
                    IdPrestadorUtilizador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdEspecialidadeMedica = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorUtilizador", x => x.IdPrestadorUtilizador);
                    table.ForeignKey(
                        name: "FK_PrestadorUtilizador_EspecialidadeMedica_IdEspecialidadeMedica",
                        column: x => x.IdEspecialidadeMedica,
                        principalTable: "EspecialidadeMedica",
                        principalColumn: "IdEspecialidadeMedica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrestadorUtilizador_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestador_IdMunicipio",
                table: "Prestador",
                column: "IdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorUtilizador_IdEspecialidadeMedica",
                table: "PrestadorUtilizador",
                column: "IdEspecialidadeMedica");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorUtilizador_IdUser",
                table: "PrestadorUtilizador",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "PrestadorUtilizador");
        }
    }
}
