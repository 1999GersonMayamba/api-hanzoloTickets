using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ManutencaoZonaUnidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodAgencia",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdZona",
                table: "Unidade",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel1",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel2",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone1",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone2",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsaap1",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsaap2",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    IdZona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.IdZona);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdZona",
                table: "Unidade",
                column: "IdZona");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_Zona_IdZona",
                table: "Unidade",
                column: "IdZona",
                principalTable: "Zona",
                principalColumn: "IdZona",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_Zona_IdZona",
                table: "Unidade");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropIndex(
                name: "IX_Unidade_IdZona",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "CodAgencia",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Email1",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "IdZona",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Responsavel1",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Responsavel2",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Telefone1",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Telefone2",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Whatsaap1",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Whatsaap2",
                table: "Unidade");
        }
    }
}
