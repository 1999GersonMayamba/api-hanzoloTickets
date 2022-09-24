using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class modelagemManutencaoSubFamiliaPrioridade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPrioridade",
                table: "Manutencao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdSubFamilia",
                table: "Manutencao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdPrioridade",
                table: "Manutencao",
                column: "IdPrioridade");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdSubFamilia",
                table: "Manutencao",
                column: "IdSubFamilia");

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Prioridade_IdPrioridade",
                table: "Manutencao",
                column: "IdPrioridade",
                principalTable: "Prioridade",
                principalColumn: "IdPrioridade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_SubFamilia_IdSubFamilia",
                table: "Manutencao",
                column: "IdSubFamilia",
                principalTable: "SubFamilia",
                principalColumn: "IdSubFamilia",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Prioridade_IdPrioridade",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_SubFamilia_IdSubFamilia",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_IdPrioridade",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_IdSubFamilia",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "IdPrioridade",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "IdSubFamilia",
                table: "Manutencao");
        }
    }
}
