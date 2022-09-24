using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class modelagemComuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    IdComuna = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMunicipio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => x.IdComuna);
                    table.ForeignKey(
                        name: "FK_Comuna_Municipio_IdMunicipio",
                        column: x => x.IdMunicipio,
                        principalTable: "Municipio",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comuna_IdMunicipio",
                table: "Comuna",
                column: "IdMunicipio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comuna");
        }
    }
}
