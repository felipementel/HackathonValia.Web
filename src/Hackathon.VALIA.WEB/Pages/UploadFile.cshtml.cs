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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=sacdesafiovalia;AccountKey=V0HTc6jddtqyKASHRWmWALyqCxFqft8yZ/nOfYDCN2jPM5R0Nq+xue/RmOSb6oKE22BsOukbNIF8tSqhkbKiAg==;EndpointSuffix=core.windows.net");
            // Create a CloudFileClient object for credentialed access to Azure Files.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("patrocinador1");

            await share.CreateIfNotExistsAsync();
            // Ensure that the share exists.

            // Get a reference to the root directory for the share.
            CloudFileDirectory rootDir = share.GetRootDirectoryReference();

            // Get a reference to the directory we created previously.
            CloudFileDirectory sampleDir = rootDir.GetDirectoryReference(DateTime.Now.ToString("yyyyMMdd"));

            sampleDir.CreateIfNotExistsAsync();

            FileInfo fileUpload = new FileInfo(@"c:\Temp\patrocinador2.txt");

            var cloudFile = sampleDir.GetFileReference("myfile.txt");

            using (FileStream fs = fileUpload.OpenRead())
            {
                await cloudFile.UploadFromStreamAsync(fs);
            }

            // Get a reference to the file we created previously.
            CloudFile fileDownload = sampleDir.GetFileReference("myfile.txt");

            await fileDownload.DownloadToFileAsync(@"c:\luiZ.txt", FileMode.CreateNew);

            //// Ensure that the file exists.
            //if (await fileDownload.ExistsAsync())
            //{
            //    // Write the contents of the file to the console window.
            //    Console.WriteLine(file.DownloadTextAsync().Result);
            //}

        }
    }
}