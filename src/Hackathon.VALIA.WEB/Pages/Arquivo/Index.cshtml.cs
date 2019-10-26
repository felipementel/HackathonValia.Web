using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            Arquivo = _context.Arquivos.ToListAsync().Result.Where(p => p.User == HttpContext.User.Identity.Name.Replace(".", "").Replace(".", "").Split("@").First()).ToList<Models.Arquivo>();
        }
    }
}
