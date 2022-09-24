using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class ChangeModelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_TipoUtilizador_IdTipoUtilizador",
                schema: "Identity",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoUtilizador",
                schema: "Identity",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivo",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TipoUtilizador_IdTipoUtilizador",
                schema: "Identity",
                table: "User",
                column: "IdTipoUtilizador",
                principalSchema: "Identity",
                principalTable: "TipoUtilizador",
                principalColumn: "IdTipoUtilizador",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_TipoUtilizador_IdTipoUtilizador",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActivo",
                schema: "Identity",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoUtilizador",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
