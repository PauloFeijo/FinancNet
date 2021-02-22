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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PaiId = table.Column<long>(type: "bigint", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoria_categoria_PaiId",
                        column: x => x.PaiId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Saldo = table.Column<double>(type: "double", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Login = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Senha = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    ContaId = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaId = table.Column<long>(type: "bigint", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lancamento_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamento_conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transferencia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContaDebitoId = table.Column<long>(type: "bigint", nullable: false),
                    ContaCreditoId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transferencia_conta_ContaCreditoId",
                        column: x => x.ContaCreditoId,
                        principalTable: "conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transferencia_conta_ContaDebitoId",
                        column: x => x.ContaDebitoId,
                        principalTable: "conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoria_PaiId",
                table: "categoria",
                column: "PaiId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_CategoriaId",
                table: "lancamento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_ContaId",
                table: "lancamento",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_ContaCreditoId",
                table: "transferencia",
                column: "ContaCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_ContaDebitoId",
                table: "transferencia",
                column: "ContaDebitoId");
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
