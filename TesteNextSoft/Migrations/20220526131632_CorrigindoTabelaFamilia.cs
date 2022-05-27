using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteNextSoft.Migrations
{
    public partial class CorrigindoTabelaFamilia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Morador",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Morador");
        }
    }
}
