using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.VALIA.WEB.Migrations.ApplicationDb
{
    public partial class nullErroId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ErroId",
                table: "Arquivos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ErroId",
                table: "Arquivos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
