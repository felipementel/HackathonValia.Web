using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.VALIA.WEB.Pages.Arquivo
{
    public class IndexModel : PageModel
    {
        private readonly Hackathon.VALIA.WEB.Data.ApplicationDbContext _context;

        public IndexModel(Hackathon.VALIA.WEB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Arquivo> Arquivo { get; set; }

        public async Task OnGetAsync()
        {
            Arquivo = await _context.Arquivos.ToListAsync();
        }
    }
}
