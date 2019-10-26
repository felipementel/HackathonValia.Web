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
    public class IndexModel : PageModel
    {
        private readonly Hackathon.VALIA.WEB.Data.ApplicationDbContext _context;

        public IndexModel(Hackathon.VALIA.WEB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Erros> Erros { get;set; }

        public async Task OnGetAsync()
        {
            Erros = await _context.Erros.ToListAsync();
        }
    }
}
