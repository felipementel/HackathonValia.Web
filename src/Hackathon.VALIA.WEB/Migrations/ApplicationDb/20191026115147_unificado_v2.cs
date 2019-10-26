using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.VALIA.WEB.Migrations.ApplicationDb
{
    public partial class unificado_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Erros",
                table: "Erros");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Erros");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Arquivos");

            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Erros",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Arquivos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Erros",
                table: "Erros",
                column: "ErroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Erros",
                table: "Erros");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Erros");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Arquivos");

            migrationBuilder.AddColumn<int>(
                name: "LinhaId",
                table: "Erros",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LinhaId",
                table: "Arquivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Erros",
                table: "Erros",
                column: "LinhaId");
        }
    }
}
