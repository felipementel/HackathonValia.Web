using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.VALIA.WEB.Migrations.ApplicationDb
{
    public partial class dnuiewndawu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Campo",
                table: "Erros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Campo",
                table: "Erros");
        }
    }
}
