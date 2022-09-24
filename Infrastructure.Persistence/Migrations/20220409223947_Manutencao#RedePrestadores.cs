using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ManutencaoRedePrestadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPrestador",
                table: "PrestadorUtilizador",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdPrestador",
                table: "Manutencao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlocacaoManutencao",
                columns: table => new
                {
                    IdAlocacaoManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataManutencao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdManutencao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlocacaoManutencao", x => x.IdAlocacaoManutencao);
                    table.ForeignKey(
                        name: "FK_AlocacaoManutencao_Manutencao_IdManutencao",
                        column: x => x.IdManutencao,
                        principalTable: "Manutencao",
                        principalColumn: "IdManutencao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlocacaoManutencao_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorUtilizador_IdPrestador",
                table: "PrestadorUtilizador",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_IdPrestador",
                table: "Manutencao",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoManutencao_IdManutencao",
                table: "AlocacaoManutencao",
                column: "IdManutencao");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoManutencao_IdUser",
                table: "AlocacaoManutencao",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Prestador_IdPrestador",
                table: "Manutencao",
                column: "IdPrestador",
                principalTable: "Prestador",
                principalColumn: "IdPrestador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorUtilizador_Prestador_IdPrestador",
                table: "PrestadorUtilizador",
                column: "IdPrestador",
                principalTable: "Prestador",
                principalColumn: "IdPrestador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Prestador_IdPrestador",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorUtilizador_Prestador_IdPrestador",
                table: "PrestadorUtilizador");

            migrationBuilder.DropTable(
                name: "AlocacaoManutencao");

            migrationBuilder.DropIndex(
                name: "IX_PrestadorUtilizador_IdPrestador",
                table: "PrestadorUtilizador");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_IdPrestador",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "IdPrestador",
                table: "PrestadorUtilizador");

            migrationBuilder.DropColumn(
                name: "IdPrestador",
                table: "Manutencao");
        }
    }
}
