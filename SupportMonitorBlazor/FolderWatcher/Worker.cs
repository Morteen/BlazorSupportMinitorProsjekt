using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
namespace FolderWatcher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
       private string ApiUrl;
        private int TmsIdfromSettings;
   
       
       
      
        public Worker(ILogger<Worker> logger,IConfiguration config)
        {
            _logger = logger;
            _config = config;

        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            

        
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            /*Henter informasjon fra appsettings.json filen*/

            TmsIdfromSettings = _config.GetValue<int>("TmsInfo:TmsId");
            var FileAdressArrey = _config.GetSection("TmsInfo:FileAdressArrey").Get<string[]>();
            ApiUrl = _config.GetValue<string>("TmsInfo:ApiUrl");
            Console.WriteLine("Dette er en Apiadressen:" + ApiUrl);
            /*   foreach(string folderLocation in FileAdressArrey)
               {
                   Console.WriteLine("Dette er en adresse"+ folderLocation);
               }*/


            //string test = _config.GetValue<string>("MySettings");
            //string FileAdressFromSettings = _config.GetValue<string>("TmsInfo:FileAdress");

            foreach (string folderLocation in FileAdressArrey)
            {
                 string FolderLocationIncludingEscapeSigne = @"";
                FolderLocationIncludingEscapeSigne += folderLocation;
                Console.WriteLine("Dette er en adresse" + folderLocation + " Og den mappen er så stor:"+ CalculateFolderSize(FolderLocationIncludingEscapeSigne));
            }
            await CheckFolderSize(FileAdressArrey);


            
          


            //while (!stoppingToken.IsCancellationRequested)
            //{

            FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = @"C:\Users\morten.olsen\Desktop\MyWatcherTestFolder";
                watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.Size;
                watcher.Filter = "*.*";
                watcher.Changed += new FileSystemEventHandler(onChange);
                watcher.Created += new FileSystemEventHandler(onChange);
                watcher.Deleted += new FileSystemEventHandler(onChange);
                watcher.Renamed += new RenamedEventHandler(onRenamed);
           

                //Start monitoring
                watcher.EnableRaisingEvents = true;

            //  _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //  await Task.Delay(1000, stoppingToken);
           
        }

        public void onChange(object source, FileSystemEventArgs e) {
            _logger.LogInformation(e.Name+" er  "+e.ChangeType);
        }


        public async void onRenamed(object source, RenamedEventArgs e)
        {
            _logger.LogInformation(e.OldName + " er endret til  " + e.Name + " Foldersize test " );


            var folderSize = Convert.ToInt32(CalculateFolderSize(@"C:\Users\morten.olsen\Desktop\MyWatcherTestFolder"));
            var space = new DiskSpace {Id=1, TmsId = 2,Name="E",Type=e.Name,FreespacePercentMinimum=1,FrespaceMinimumBytes=11, Actualsize = folderSize,MaxSize=2 };
          
           await UpdateDiskSpace(space);
          


        }

        //function to calculate the size of the given path
        private float CalculateFolderSize(string folder)
        {
            float folderSize = 0.0f;
            try
            {
                //Checks if the path is valid or not         
                if (!Directory.Exists(folder))
                {
                    return folderSize;
                }
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo finfo = new FileInfo(file);
                                folderSize += finfo.Length;
                            }
                        }
                        foreach (string dir in Directory.GetDirectories(folder))
                        {
                            folderSize += CalculateFolderSize(dir);
                        }
                    }
                    catch (NotSupportedException ex)
                    {
                        //eventLogCheck.WriteEntry(ex.ToString());
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                //eventLogCheck.WriteEntry(ex.ToString());
            }
            return folderSize;
        }


      
        private static async Task UpdateDiskSpace(DiskSpace space)
        {
           

            HttpClient client = new HttpClient();
           
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            HttpResponseMessage response;


                response = await client.PutAsJsonAsync<DiskSpace>(Constants.WebApiUrl,space);
            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine("denne mappen er oppdatert:" + space.Name);
            }
            else { Console.WriteLine("Det er noe galt: " + response.ReasonPhrase); }



            }
        private async Task CheckFolderSize(string[] FileAdressArrey)
        {
            int index = 1;
            foreach (string folderLocation in FileAdressArrey)
            {
                string FolderLocationIncludingEscapeSigne = @"";
                FolderLocationIncludingEscapeSigne += folderLocation;
                Console.WriteLine("Dette er en adresse" + folderLocation + " Og den mappen er så stor:" + CalculateFolderSize(FolderLocationIncludingEscapeSigne)+ "Index verdi: "+ index+" Tms id from setting: "+ TmsIdfromSettings);
                var space = new DiskSpace { Id = index+1000, TmsId = TmsIdfromSettings, Name = "E", Type = "Test", FreespacePercentMinimum = 1, FrespaceMinimumBytes = 11, Actualsize =Convert.ToInt32( CalculateFolderSize(FolderLocationIncludingEscapeSigne)/100), MaxSize = 30000000 };
                 await UpdateDiskSpace(space);
                index++;
            }

          

        }


      






    }

   


}
