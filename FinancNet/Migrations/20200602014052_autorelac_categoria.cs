using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancNet.Migrations
{
    public partial class autorelac_categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "paiId",
                table: "categoria",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paiId",
                table: "categoria");
        }
    }
}
