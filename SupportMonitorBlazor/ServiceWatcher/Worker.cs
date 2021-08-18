using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using SupportMonitorBlazor.Models;
using System.Net.Http.Json;

namespace ServiceWatcher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        ServiceController[] scServices;
        TMS_Services TMS_Services;
        private int _TmsId;
        private string DefaultServiceStatus="Running";
        int index = 102;
        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var ServiceDisplayName = _config.GetSection("TmsInfo:ServiceDisplayName").Get<string[]>();
           // var ServiceDisplayName = _config.GetSection("Test:ServiceDisplayName").Get<string[]>();
            //var nameIndex = _config.GetSection("Test:Id").Get<int[]>();
            _TmsId = _config.GetValue<int>("TmsInfo:TmsId");
            while (!stoppingToken.IsCancellationRequested)
            {
                scServices = ServiceController.GetServices();
                foreach (ServiceController scTemp in scServices)
                {
                   
                    foreach (string name in ServiceDisplayName) {
                      
                        if (scTemp.ServiceName == name)
                    {
                            var serviceToCheck = new TMS_Services { Id = index, TMS_Id = _TmsId, Status = DefaultServiceStatus, Name = scTemp.ServiceName, DisplayName = scTemp.DisplayName, RunningSince = DateTime.Now };
                            if (scTemp.Status.ToString() != DefaultServiceStatus)
                            {
                                
                            
                                serviceToCheck.Status = scTemp.Status.ToString();
                                Console.WriteLine("Indexverdi:" + index + " Id:" + serviceToCheck.Id + " Service Navn:" + serviceToCheck.Name + "  Status:" + serviceToCheck.Status + " Dispaly name:" + serviceToCheck.DisplayName + " TMS_Id:" + serviceToCheck.TMS_Id);
                                await UpdateServiceStatus(serviceToCheck);
                            }
                            Console.WriteLine("Indexverdi:" + index + " Id:" + serviceToCheck.Id + " Service Navn:" + serviceToCheck.Name + "  Status:" + serviceToCheck.Status + " Dispaly name:" + serviceToCheck.DisplayName + " TMS_Id:" + serviceToCheck.TMS_Id);


                        }
                        index = index + 1;
                    }
                  
                }
                     //   _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(4000, stoppingToken);
            }
        }





        private static async Task UpdateServiceStatus(TMS_Services service)
        {


            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            HttpResponseMessage response;


            response = await client.PostAsJsonAsync<TMS_Services>("https://localhost:44388/api/TMS_Services", service);
            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine("Denneservicen er oppdatert:" + service.Name);
            }
            else { Console.WriteLine("Det er noe galt: " + response.ReasonPhrase); }

            client.Dispose();

        }
    }
}
