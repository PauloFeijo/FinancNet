using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancNet.Migrations
{
    public partial class create_conta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conta",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    descricao = table.Column<string>(nullable: true),
                    numero = table.Column<string>(nullable: true),
                    saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conta", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conta");
        }
    }
}
