using Microsoft.EntityFrameworkCore;

namespace Hackathon.VALIA.WEB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Arquivo> Arquivos { get; set; }
        public DbSet<Models.Erros> Erros { get; set; }
        public DbSet<Models.TipoArquivo> TipoArquivos { get; set; }
    }
}
