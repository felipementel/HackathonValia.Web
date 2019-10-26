using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.VALIA.WEB.Migrations.ApplicationDb
{
    public partial class unificado_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinhaId",
                table: "Arquivos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Erros",
                columns: table => new
                {
                    LinhaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicaoInicial = table.Column<int>(nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    ArquivoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erros", x => x.LinhaId);
                    table.ForeignKey(
                        name: "FK_Erros_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "ArquivoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Erros_ArquivoId",
                table: "Erros",
                column: "ArquivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Erros");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Arquivos");
        }
    }
}
