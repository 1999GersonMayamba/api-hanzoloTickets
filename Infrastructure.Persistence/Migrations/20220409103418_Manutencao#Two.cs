using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ManutencaoTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdTipoUnidade",
                table: "Unidade",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Unidade",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Unidade",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrigemManutencao",
                table: "Manutencao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoUnidade",
                columns: table => new
                {
                    IdTipoUnidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUnidade", x => x.IdTipoUnidade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdTipoUnidade",
                table: "Unidade",
                column: "IdTipoUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdOrigemManutencao",
                table: "Manutencao",
                column: "IdOrigemManutencao");

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_OrigemManutencao_IdOrigemManutencao",
                table: "Manutencao",
                column: "IdOrigemManutencao",
                principalTable: "OrigemManutencao",
                principalColumn: "IdOrigemManutencao",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_TipoUnidade_IdTipoUnidade",
                table: "Unidade",
                column: "IdTipoUnidade",
                principalTable: "TipoUnidade",
                principalColumn: "IdTipoUnidade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_OrigemManutencao_IdOrigemManutencao",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_TipoUnidade_IdTipoUnidade",
                table: "Unidade");

            migrationBuilder.DropTable(
                name: "TipoUnidade");

            migrationBuilder.DropIndex(
                name: "IX_Unidade_IdTipoUnidade",
                table: "Unidade");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_IdOrigemManutencao",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "IdTipoUnidade",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "IdOrigemManutencao",
                table: "Manutencao");
        }
    }
}
