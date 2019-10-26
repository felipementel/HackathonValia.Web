using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.WindowsAzure.Storage.File;
using POCAttribute.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POCAttribute
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            do
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var config = builder.Build();

                TelemetryConfiguration telemetryConfig = TelemetryConfiguration.CreateDefault();
                telemetryConfig.InstrumentationKey = config.GetSection("ApplicationInsights:InstrumentationKey").Value;
                TelemetryClient telemetryClient = new TelemetryClient(telemetryConfig);

                try
                {
                    Setup.SetCulture();

                    AzureFileStorageClient fileStorageClient = new AzureFileStorageClient();
                    var cloudFiles = await fileStorageClient.GetFiles();

                    //if (Directory.Exists(config["FilesDirectory"]))
                    //{
                    //    DirectoryInfo dirInfo = new DirectoryInfo(config["FilesDirectory"]);
                    foreach (CloudFile cloudFile in cloudFiles)
                    {
                        //var lines = File.ReadLines(filePath);
                        //string lines = cloudFile.DownloadTextAsync().Result;

                        FileInfo f = new FileInfo(Path.Combine(@"\\FELIPE-DELLG7\Temp\", Path.GetFileName(cloudFile.Name)));
                        //File.Create(Path.Combine(@"\\FELIPE-DELLG7\Temp\", Path.GetFileName(cloudFile.Name)));
                        if (File.Exists(f.FullName))
                        {
                            StreamReader stream = new StreamReader(Path.Combine(@"\\FELIPE-DELLG7\Temp\", Path.GetFileName(cloudFile.Name)));
                            //using (var stream = await cloudFile.OpenReadAsync())
                            {
                                int count = 0;
                                bool isContent;
                                string line;

                                //if (lineCount > 2)
                                //{
                                //using (StreamReader reader = new StreamReader(stream))
                                //{
                                while (!stream.EndOfStream)
                                {
                                    Console.WriteLine();
                                    line = stream.ReadLine();
                                    count++;
                                    isContent = count > 1;

                                    if (isContent)
                                    {
                                        Empregado empregado = new Empregado(line, count, cloudFile.Name);
                                        Console.WriteLine(string.Format("Fim do processamento da linha {0}", count));
                                    }
                                }
                                //Console.WriteLine("Fim do processamento do arquivo \"{0}\"", cloudFile.Name);
                                //}
                                //}
                                //else
                                //{
                                //    throw new FileLoadException("O arquivo não pode ser processado pois deve conter no mínimo três linhas: header, conteúdo e trailer.");
                                //}
                            }
                            stream.Close();
                        }

                        File.Move(Path.Combine(@"\\FELIPE-DELLG7\Temp\", Path.GetFileName(cloudFile.Name)), Path.Combine(@"\\FELIPE-DELLG7\Temp2\", Path.GetFileName(cloudFile.Name)));
                    }

                    //Console.ReadKey();
                }
                catch (Exception ex)
                {
                    telemetryClient.TrackException(ex);
                }

                Thread.Sleep(1000);
            } while (true);
        }
    }
}