using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hackathon.VALIA.WEB.Data;
using Hackathon.VALIA.WEB.Models;

namespace Hackathon.VALIA.WEB.Pages.Erros
{
    public class DeleteModel : PageModel
    {
        private readonly Hackathon.VALIA.WEB.Data.ApplicationDbContext _context;

        public DeleteModel(Hackathon.VALIA.WEB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Erros Erros { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Erros = await _context.Erros.FirstOrDefaultAsync(m => m.ErroId == id);

            if (Erros == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Erros = await _context.Erros.FindAsync(id);

            if (Erros != null)
            {
                _context.Erros.Remove(Erros);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
