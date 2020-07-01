using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancNet.Migrations
{
    public partial class ajusta_autorelac_categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_categoria_categoria_paiId",
                table: "categoria",
                column: "paiId",
                principalTable: "categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoria_categoria_paiId",
                table: "categoria");
        }
    }
}
