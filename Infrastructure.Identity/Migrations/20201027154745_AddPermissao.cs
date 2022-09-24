using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class AddPermissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoUtilizador",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GruposPermissoes",
                schema: "Identity",
                columns: table => new
                {
                    IdGrupoPermissao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposPermissoes", x => x.IdGrupoPermissao);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedByIp = table.Column<string>(nullable: true),
                    Revoked = table.Column<DateTime>(nullable: true),
                    RevokedByIp = table.Column<string>(nullable: true),
                    ReplacedByToken = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoUtilizador",
                schema: "Identity",
                columns: table => new
                {
                    IdTipoUtilizador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUtilizador", x => x.IdTipoUtilizador);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                schema: "Identity",
                columns: table => new
                {
                    IdPermissao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    IdGrupoPermissao = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.IdPermissao);
                    table.ForeignKey(
                        name: "FK_Permissoes_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissoes_GruposPermissoes_IdGrupoPermissao",
                        column: x => x.IdGrupoPermissao,
                        principalSchema: "Identity",
                        principalTable: "GruposPermissoes",
                        principalColumn: "IdGrupoPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TipoUtilizador",
                columns: new[] { "IdTipoUtilizador", "Descricao" },
                values: new object[] { 1, "HR" });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdTipoUtilizador",
                schema: "Identity",
                table: "User",
                column: "IdTipoUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_ApplicationUserId",
                schema: "Identity",
                table: "Permissoes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_IdGrupoPermissao",
                schema: "Identity",
                table: "Permissoes",
                column: "IdGrupoPermissao");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_ApplicationUserId",
                schema: "Identity",
                table: "RefreshToken",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_TipoUtilizador_IdTipoUtilizador",
                schema: "Identity",
                table: "User",
                column: "IdTipoUtilizador",
                principalSchema: "Identity",
                principalTable: "TipoUtilizador",
                principalColumn: "IdTipoUtilizador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_TipoUtilizador_IdTipoUtilizador",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "Permissoes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TipoUtilizador",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "GruposPermissoes",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_User_IdTipoUtilizador",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdTipoUtilizador",
                schema: "Identity",
                table: "User");
        }
    }
}
