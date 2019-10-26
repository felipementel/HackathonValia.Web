using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hackathon.VALIA.WEB.Pages
{
    [Authorize]
    public class UploadFileModel : PageModel
    {
        private IWebHostEnvironment _webhostenvironment;

        public UploadFileModel(IWebHostEnvironment webhostenvironment)
        {
            _webhostenvironment = webhostenvironment;
        }
        public void OnGet()
        {

        }

        [BindProperty]
        public IFormFile UploadArquivo1 { get; set; }

        [BindProperty]
        public IFormFile UploadArquivo2 { get; set; }

        public async Task OnPostAsync()
        {
            string FileUserDate = Path.Combine(
                @"C:\Temp",
                "uploads",
                "new",
                HttpContext.User.Identity.Name.Split("@").First(),
                DateTime.Now.ToString("yyyyMMdd"));

            if (!Directory.Exists(FileUserDate))
                Directory.CreateDirectory(FileUserDate);

            using (var fileStream = new FileStream(FileUserDate, FileMode.Create))
            {
                await UploadArquivo1.CopyToAsync(fileStream);
                await UploadArquivo2.CopyToAsync(fileStream);
            }
        }
    }
}