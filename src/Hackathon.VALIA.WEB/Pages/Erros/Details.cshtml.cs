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
    public class DetailsModel : PageModel
    {
        private readonly Hackathon.VALIA.WEB.Data.ApplicationDbContext _context;

        public DetailsModel(Hackathon.VALIA.WEB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Erros> Erros { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Erros = await _context.Erros.Where(m => m.ArquivoId == id).ToListAsync();

            if (Erros == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
