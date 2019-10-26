using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;

namespace Hackathon.VALIA.WEB.Pages
{
    [Authorize]
    public class UploadFileModel : PageModel
    {
        private IWebHostEnvironment _webhostenvironment;
        private readonly Hackathon.VALIA.WEB.Data.ApplicationDbContext _context;

        public UploadFileModel(IWebHostEnvironment webhostenvironment,
            Hackathon.VALIA.WEB.Data.ApplicationDbContext context)
        {
            _webhostenvironment = webhostenvironment;
            _context = context;
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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=sacdesafiovalia;AccountKey=V0HTc6jddtqyKASHRWmWALyqCxFqft8yZ/nOfYDCN2jPM5R0Nq+xue/RmOSb6oKE22BsOukbNIF8tSqhkbKiAg==;EndpointSuffix=core.windows.net");


            // Create a CloudFileClient object for credentialed access to Azure Files.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("pat" + HttpContext.User.Identity.Name.Replace(".","").Replace(".", "").Split("@").First());

            await share.CreateIfNotExistsAsync();
            // Ensure that the share exists.

            // Get a reference to the root directory for the share.
            CloudFileDirectory rootDir = share.GetRootDirectoryReference();

            // Get a reference to the directory we created previously.
            CloudFileDirectory sampleDir = rootDir.GetDirectoryReference(DateTime.Now.ToString("yyyyMMdd"));

            await sampleDir.CreateIfNotExistsAsync();

            Stream sr1 = UploadArquivo1.OpenReadStream();

            var cloudFile = sampleDir.GetFileReference(UploadArquivo1.FileName);

            await cloudFile.UploadFromStreamAsync(sr1);
            sr1.Close();


            StreamReader sr = new StreamReader(Path.Combine(@"C:\Users\Felipe\Downloads\", UploadArquivo1.FileName));

            //System.IO.File.Create(Path.Combine(@"C:\Users\Felipe\Downloads\", "2", UploadArquivo1.FileName));
            StreamWriter sw = new StreamWriter(Path.Combine(@"D:\OneDrive\Novo",Path.GetFileName(UploadArquivo1.FileName) + "111.txt"));
            while (!sr.EndOfStream)
            {
                sw.WriteLine(sr.ReadLine());
            }

            sr.Close();
            sw.Close();

            Models.Arquivo arq = new Models.Arquivo();
            arq.NomeArquivo = UploadArquivo1.FileName;
            arq.User = HttpContext.User.Identity.Name.Replace(".", "").Replace(".", "").Split("@").First();
            arq.Status = "Novo";
            arq.TipoArquivo = new Models.TipoArquivo();
            arq.TipoArquivo.NomeTipoArquivo = "Empregado";

            _context.Arquivos.Add(arq);

            await _context.SaveChangesAsync();

            //// vini

            //FileInfo fileUpload = new FileInfo(@"c:\Temp\patrocinador2.txt");

            /////var cloudFile = sampleDir.GetFileReference("myfile.txt");

            //using (FileStream fs = fileUpload.OpenRead())
            //{
            //    await cloudFile.UploadFromStreamAsync(fs);
            //}

            //// Get a reference to the file we created previously.
            //CloudFile fileDownload = sampleDir.GetFileReference("myfile.txt");

            //await fileDownload.DownloadToFileAsync(@"c:\luiZ.txt", FileMode.CreateNew);

            //// Ensure that the file exists.
            //if (await fileDownload.ExistsAsync())
            //{
            //    // Write the contents of the file to the console window.
            //    Console.WriteLine(file.DownloadTextAsync().Result);
            //}

        }

        public void CopyStream(Stream stream, string destPath)
        {
            using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
}