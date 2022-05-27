using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteNextSoft.Migrations
{
    public partial class AdicionandoMaisCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AreaApto",
                table: "Familia",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FracaoIdeal",
                table: "Familia",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorIptuProporcional",
                table: "Familia",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AreaTotalCondominio",
                table: "Condominio",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorIptu",
                table: "Condominio",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaApto",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "FracaoIdeal",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "ValorIptuProporcional",
                table: "Familia");

            migrationBuilder.DropColumn(
                name: "AreaTotalCondominio",
                table: "Condominio");

            migrationBuilder.DropColumn(
                name: "ValorIptu",
                table: "Condominio");
        }
    }
}
