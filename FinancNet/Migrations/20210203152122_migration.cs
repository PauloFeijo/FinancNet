using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FinancNet.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    paiId = table.Column<long>(type: "bigint", nullable: true),
                    usuario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_categoria_categoria_paiId",
                        column: x => x.paiId,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conta",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<string>(type: "text", nullable: true),
                    saldo = table.Column<double>(type: "double", nullable: false),
                    usuario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    login = table.Column<string>(type: "varchar(767)", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: true),
                    nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.login);
                });

            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<double>(type: "double", nullable: false),
                    contaId = table.Column<long>(type: "bigint", nullable: false),
                    categoriaId = table.Column<long>(type: "bigint", nullable: false),
                    usuario = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "transferencia",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contaDebitoId = table.Column<long>(type: "bigint", nullable: false),
                    contaCreditoId = table.Column<long>(type: "bigint", nullable: false),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    valor = table.Column<double>(type: "double", nullable: false),
                    usuario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_transferencia_conta_contaCreditoId",
                        column: x => x.contaCreditoId,
                        principalTable: "conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transferencia_conta_contaDebitoId",
                        column: x => x.contaDebitoId,
                        principalTable: "conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoria_paiId",
                table: "categoria",
                column: "paiId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_categoriaId",
                table: "lancamento",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_contaId",
                table: "lancamento",
                column: "contaId");

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
                name: "lancamento");

            migrationBuilder.DropTable(
                name: "transferencia");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "conta");
        }
    }
}
