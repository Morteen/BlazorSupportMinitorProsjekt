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
        private int CheckingRate;





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
            CheckingRate = _config.GetValue<int>("TmsInfo:CheckingRate");
            ApiUrl = _config.GetValue<string>("TmsInfo:ApiUrl");
            var driveArray = _config.GetSection("TmsInfo:DriveArray").Get<string[]>();



           



            foreach (string folderLocation in FileAdressArrey)
            {
                string FolderLocationIncludingEscapeSigne = @"";
                FolderLocationIncludingEscapeSigne += folderLocation;
                Console.WriteLine("Dette er en adresse" + folderLocation + " Og den mappen er så stor:" + CalculateFolderSize(FolderLocationIncludingEscapeSigne));
            }





            while (!stoppingToken.IsCancellationRequested) {

              
                await CheckFolderSize(FileAdressArrey);
                await CheckDrives(driveArray);



                await Task.Delay(CheckingRate, stoppingToken);
            }
           


           
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


                response = await client.PostAsJsonAsync<DiskSpace>(Constants.WebApiUrl,space);
            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine("Denne mappen er oppdatert:" + space.Name);
            }
            else { Console.WriteLine("Det er noe galt: " + response.ReasonPhrase); }

            client.Dispose();

            }
        private async Task CheckFolderSize(string[] FileAdressArrey)
        {
            int index = 1;
            foreach (string folderLocation in FileAdressArrey)
            {
                string FolderLocationIncludingEscapeSigne = @"";
                FolderLocationIncludingEscapeSigne += folderLocation;
           
                var space = new DiskSpace { Id = index+1000, TmsId = TmsIdfromSettings, Name = folderLocation, Type = "Test", FreespacePercentMinimum = 10, FrespaceMinimumBytes = 11, Actualsize =Convert.ToInt32( CalculateFolderSize(FolderLocationIncludingEscapeSigne)/100), MaxSize = 6666 };
                 await UpdateDiskSpace(space);
                index++;
            }

          

        }
        private async Task CheckDrives(string[] driveArray)
        {
            Console.WriteLine("Kommer inn i CheckDrives " + driveArray[0].ToString());
            foreach (string driveLocation in driveArray)
            { var result = GetTotalFreeSpace(driveLocation);
                if (result != null) {
                    if (result.TotalSize == null)
                    {
                        Console.WriteLine("result.TotalSize er null ");
                    }
                    else {
                       long i = result.TotalSize;
                        long j = result.AvailableFreeSpace;
                        int res = Convert.ToInt32(( i -j )/ (1024 * 1024 ));
                        int test = Convert.ToInt32((i)/ (1024 * 1024 ));
                        int test2= Convert.ToInt32((i*0.1)/(1024 * 1024 ));
                        Console.WriteLine("result.TotalSize er IKKE null :{0}", i); 
                   
                    var drive = new DiskSpace { TmsId = 18, Name =result.Name, Type = result.DriveType.ToString(), FreespacePercentMinimum = 10, FrespaceMinimumBytes = test2, Actualsize =res, MaxSize = test };
                    Console.WriteLine(" Sjekker om object blir opprettet TMsid:{0}, Navn: {1}, Type:{2} Actualsize{3}", drive.TmsId, drive.Name,drive.Type,drive.Actualsize);

                    await UpdateDiskSpace(drive);
                    }
                }
               
            }
           
        }



        private DriveInfo GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive; 
                }
            }
            return null;
        }






    }

   


}
