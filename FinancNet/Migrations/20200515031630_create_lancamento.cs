using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancNet.Migrations
{
    public partial class create_lancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    data = table.Column<DateTime>(nullable: false),
                    tipo = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    contaId = table.Column<long>(nullable: false),
                    categoriaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_lancamento_categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_conta_contaId",
                        column: x => x.contaId,
                        principalTable: "conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_categoriaId",
                table: "lancamento",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_contaId",
                table: "lancamento",
                column: "contaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lancamento");
        }
    }
}
