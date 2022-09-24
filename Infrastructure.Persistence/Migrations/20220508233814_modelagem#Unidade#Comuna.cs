using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class modelagemUnidadeComuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_Municipio_IdMunicipio",
                table: "Unidade");

            migrationBuilder.RenameColumn(
                name: "IdMunicipio",
                table: "Unidade",
                newName: "IdComuna");

            migrationBuilder.RenameIndex(
                name: "IX_Unidade_IdMunicipio",
                table: "Unidade",
                newName: "IX_Unidade_IdComuna");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_Comuna_IdComuna",
                table: "Unidade",
                column: "IdComuna",
                principalTable: "Comuna",
                principalColumn: "IdComuna",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_Comuna_IdComuna",
                table: "Unidade");

            migrationBuilder.RenameColumn(
                name: "IdComuna",
                table: "Unidade",
                newName: "IdMunicipio");

            migrationBuilder.RenameIndex(
                name: "IX_Unidade_IdComuna",
                table: "Unidade",
                newName: "IX_Unidade_IdMunicipio");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_Municipio_IdMunicipio",
                table: "Unidade",
                column: "IdMunicipio",
                principalTable: "Municipio",
                principalColumn: "IdMunicipio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
