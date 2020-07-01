using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancNet.Migrations
{
    public partial class createtransferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transferencia",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    contaDebitoId = table.Column<long>(nullable: false),
                    contaCreditoId = table.Column<long>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_transferencia_conta_contaCreditoId",
                        column: x => x.contaCreditoId,
                        principalTable: "conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transferencia_conta_contaDebitoId",
                        column: x => x.contaDebitoId,
                        principalTable: "conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_contaCreditoId",
                table: "transferencia",
                column: "contaCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_contaDebitoId",
                table: "transferencia",
                column: "contaDebitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transferencia");
        }
    }
}
