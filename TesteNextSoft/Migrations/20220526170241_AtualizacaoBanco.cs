using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteNextSoft.Migrations
{
    public partial class AtualizacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familia_Condominio_CondominioId",
                table: "Familia");

            migrationBuilder.DropForeignKey(
                name: "FK_Morador_Familia_FamiliaId",
                table: "Morador");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Morador",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CondominioId",
                table: "Familia",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Familia_Condominio_CondominioId",
                table: "Familia",
                column: "CondominioId",
                principalTable: "Condominio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Morador_Familia_FamiliaId",
                table: "Morador",
                column: "FamiliaId",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familia_Condominio_CondominioId",
                table: "Familia");

            migrationBuilder.DropForeignKey(
                name: "FK_Morador_Familia_FamiliaId",
                table: "Morador");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Morador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CondominioId",
                table: "Familia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Familia_Condominio_CondominioId",
                table: "Familia",
                column: "CondominioId",
                principalTable: "Condominio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Morador_Familia_FamiliaId",
                table: "Morador",
                column: "FamiliaId",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
