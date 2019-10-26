using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hackathon.VALIA.WEB.Data;

namespace Hackathon.VALIA.WEB.Pages.Arquivo
{
    public class DetailsModel : PageModel
    {
        private readonly Hackathon.VALIA.WEB.Data.ApplicationDbContext _context;

        public DetailsModel(Hackathon.VALIA.WEB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Arquivo Arquivo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Arquivo = await _context.Arquivos.FirstOrDefaultAsync(m => m.ArquivoId == id);

            if (Arquivo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
