using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;



        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client= new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

       private async Task test()
        {

            long size = 0;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\morten.olsen\Documents\Morten\Heartbeat");
            foreach (FileInfo fi in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }

            _logger.LogInformation(@"C:\Users\morten.olsen\Documents\Morten\Heartbeat");




        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           string rootPath = @"C:\Users\morten.olsen\Documents\Morten\Heartbeat\HeartbeatService";
            while (!stoppingToken.IsCancellationRequested)
            {
                /* var gausWebApi = await client.GetAsync("http://tms.gaus.no:31003/docs/");//https://web.tdxweb.se/Account/
                 var tdx = await client.GetAsync("https://web.tdxweb.se/");//https://web.tdxweb.se/Account/
                //var DsvCustomerWeb = await client.GetAsync("http://customer.test.dsv.transfleet.no/");
                //var DsVDriverWeb = await client.GetAsync("http://driverweb-test.dsv.transfleet.no");
               //var DsvTFWebApi = await client.GetAsync("http://217.65.224.224:50000/docs/index.html");

                 if (gausWebApi.IsSuccessStatusCode)
                 {
                     _logger.LogInformation("tms.gaus.no kjører "+ gausWebApi.StatusCode);
                 }
                 else {
                     _logger.LogInformation("KRISE tms.gaus.no kjører ikke: "+ gausWebApi.StatusCode);
               }
                if (tdx.IsSuccessStatusCode)
                 {
                     _logger.LogInformation("TDX kjører " + tdx.StatusCode);
                 }
                 else
                 {
                     _logger.LogInformation("KRISE TDXkjører ikke: " + tdx.StatusCode);
                 }
               /*
            if (DsvCustomerWeb.IsSuccessStatusCode)
             {
                 _logger.LogInformation("CustomerWeb kjører " + DsvCustomerWeb.StatusCode);
             }
             else
             {
                 _logger.LogError("KRISE Customerweb kjører ikke: " + DsvCustomerWeb.StatusCode);
             } 
             if (DsVDriverWeb.IsSuccessStatusCode)
             {
                 _logger.LogInformation("Driverweb kjører " + DsVDriverWeb.StatusCode);
             }
             else
             {
                 _logger.LogError("KRISE Driverweb kjører ikke: " + DsVDriverWeb.StatusCode);
             }/*
             if (DsvTFWebApi.IsSuccessStatusCode)
             {
                 _logger.LogInformation("DsvTFWebApi kjører " + DsvTFWebApi.StatusCode);
             }
             else
             {
                 _logger.LogError("KRISE DsvTFWebApi kjører ikke: " + DsvTFWebApi.StatusCode);
             }*/



                _logger.LogInformation("Worker2 running at: "+  GetDirectorySize(rootPath));

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

              

              
                //  _logger.LogInformation("Test:"+GetDirectorySize(rootPath));
                //await test();
                await Task.Delay(5000, stoppingToken);
                
            }
        }
        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, " *.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }
    }

}
