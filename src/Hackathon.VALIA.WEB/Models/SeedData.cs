using Hackathon.VALIA.WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Hackathon.VALIA.WEB.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.TipoArquivos.Any())
                {
                    return;   // DB has been seeded
                }

                context.TipoArquivos.AddRange(
                    new TipoArquivo
                    {
                        NomeTipoArquivo = "Empregado"
                    },

                    new TipoArquivo
                    {
                        NomeTipoArquivo = "Contribuicao"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
