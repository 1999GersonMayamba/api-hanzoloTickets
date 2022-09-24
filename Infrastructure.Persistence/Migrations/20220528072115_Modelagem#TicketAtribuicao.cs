using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class ModelagemTicketAtribuicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketAtribuicao",
                columns: table => new
                {
                    IdTicketAtribuicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTicket = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAtribuicao", x => x.IdTicketAtribuicao);
                    table.ForeignKey(
                        name: "FK_TicketAtribuicao_Manutencao_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Manutencao",
                        principalColumn: "IdManutencao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketAtribuicao_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketAtribuicao_IdTicket",
                table: "TicketAtribuicao",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAtribuicao_IdUser",
                table: "TicketAtribuicao",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketAtribuicao");
        }
    }
}
