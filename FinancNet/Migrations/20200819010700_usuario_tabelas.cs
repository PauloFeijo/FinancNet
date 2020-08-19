using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancNet.Migrations
{
    public partial class usuario_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "transferencia",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "lancamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "conta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "categoria",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuario",
                table: "transferencia");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "lancamento");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "conta");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "categoria");
        }
    }
}
