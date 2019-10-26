using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace POCAttribute
{
    class AzureFileStorageClient
    {

        public readonly static string AzureStorageAccount = "DefaultEndpointsProtocol=https;AccountName=sacdesafiovalia;AccountKey=V0HTc6jddtqyKASHRWmWALyqCxFqft8yZ/nOfYDCN2jPM5R0Nq+xue/RmOSb6oKE22BsOukbNIF8tSqhkbKiAg==;EndpointSuffix=core.windows.net";
        public async Task DownloadFile()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(AzureStorageAccount);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            FileContinuationToken token = null;
            ShareResultSegment shareResultSegment = await fileClient.ListSharesSegmentedAsync("Pat", token);

            foreach (CloudFileShare share in shareResultSegment.Results)
            {
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();
                CloudFileDirectory sampleDir = rootDir.GetDirectoryReference(DateTime.Now.ToString("yyyyMMdd"));
                if (await sampleDir.ExistsAsync())
                {
                    do
                    {
                        FileResultSegment resultSegment = await sampleDir.ListFilesAndDirectoriesSegmentedAsync(token);
                        token = resultSegment.ContinuationToken;

                        List<IListFileItem> listedFileItems = new List<IListFileItem>();

                        foreach (IListFileItem listResultItem in resultSegment.Results)
                        {
                            var cloudFile = sampleDir.GetFileReference(listResultItem.Uri.ToString());
                            Console.WriteLine(cloudFile.Uri.ToString());
                            //await cloudFile.DownloadToFileAsync(cloudFile.Uri.ToString(), FileMode.Create);
                        }
                    }
                    while (token != null);
                }
            }
        }

    }
}
