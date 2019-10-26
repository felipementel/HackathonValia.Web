using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.VALIA.WEB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoArquivos",
                columns: table => new
                {
                    TipoArquivoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoArquivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArquivos", x => x.TipoArquivoId);
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    ArquivoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeArquivo = table.Column<string>(maxLength: 200, nullable: true),
                    User = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ErroId = table.Column<int>(nullable: true),
                    TipoArquivoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.ArquivoId);
                    table.ForeignKey(
                        name: "FK_Arquivos_TipoArquivos_TipoArquivoId",
                        column: x => x.TipoArquivoId,
                        principalTable: "TipoArquivos",
                        principalColumn: "TipoArquivoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Erros",
                columns: table => new
                {
                    ErroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicaoInicial = table.Column<int>(nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    Campo = table.Column<string>(nullable: true),
                    ArquivoId = table.Column<int>(nullable: false),
                    Linha = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erros", x => x.ErroId);
                    table.ForeignKey(
                        name: "FK_Erros_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "ArquivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_TipoArquivoId",
                table: "Arquivos",
                column: "TipoArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Erros_ArquivoId",
                table: "Erros",
                column: "ArquivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Erros");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "TipoArquivos");
        }
    }
}
