using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class AdicaoTabelaPermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_User_ApplicationUserId",
                schema: "Identity",
                table: "Permissoes");

            migrationBuilder.DropIndex(
                name: "IX_Permissoes_ApplicationUserId",
                schema: "Identity",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Permissoes");

            migrationBuilder.CreateTable(
                name: "PermissoesUtilizadores",
                schema: "Identity",
                columns: table => new
                {
                    IdPermissaoUtilizador = table.Column<Guid>(nullable: false),
                    IdPermissao = table.Column<int>(nullable: false),
                    IdUtilizador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissoesUtilizadores", x => x.IdPermissaoUtilizador);
                    table.ForeignKey(
                        name: "FK_PermissoesUtilizadores_Permissoes_IdPermissao",
                        column: x => x.IdPermissao,
                        principalSchema: "Identity",
                        principalTable: "Permissoes",
                        principalColumn: "IdPermissao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissoesUtilizadores_User_IdUtilizador",
                        column: x => x.IdUtilizador,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissoesUtilizadores_IdPermissao",
                schema: "Identity",
                table: "PermissoesUtilizadores",
                column: "IdPermissao");

            migrationBuilder.CreateIndex(
                name: "IX_PermissoesUtilizadores_IdUtilizador",
                schema: "Identity",
                table: "PermissoesUtilizadores",
                column: "IdUtilizador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissoesUtilizadores",
                schema: "Identity");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Permissoes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_ApplicationUserId",
                schema: "Identity",
                table: "Permissoes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_User_ApplicationUserId",
                schema: "Identity",
                table: "Permissoes",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
