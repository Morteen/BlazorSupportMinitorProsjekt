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
        string starttype;
        int CheckingRate;
        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var ServiceDisplayName = _config.GetSection("TmsInfo:ServiceDisplayName").Get<string[]>();
            CheckingRate = _config.GetValue<int>("TmsInfo:CheckingRate");
            _TmsId = _config.GetValue<int>("TmsInfo:TmsId");
            while (!stoppingToken.IsCancellationRequested)
            {
                scServices = ServiceController.GetServices();
                foreach (ServiceController scTemp in scServices)
                {
                   
                    foreach (string name in ServiceDisplayName) {
                      
                        if (scTemp.ServiceName == name)
                    {
                            var serviceToCheck = new TMS_Services { TMS_Id = _TmsId, Status = DefaultServiceStatus, Name = scTemp.ServiceName, DisplayName = scTemp.DisplayName, RunningSince = DateTime.Now };
                          
                                
                            
                                serviceToCheck.Status = scTemp.Status.ToString();
                                starttype  = scTemp.StartType.ToString();
                           
                                Console.WriteLine(" Id:" + serviceToCheck.Id + " Service Navn:" + serviceToCheck.Name + "  Status:" + serviceToCheck.Status + " Dispaly name:" + serviceToCheck.DisplayName + " TMS_Id:" + serviceToCheck.TMS_Id,serviceToCheck.StartType= starttype);
                                await UpdateServiceStatus(serviceToCheck);
                          
                            Console.WriteLine( " Id:" + serviceToCheck.Id + " Service Navn:" + serviceToCheck.Name + 
                                "  Status:" + serviceToCheck.Status + " Dispaly name:" + serviceToCheck.DisplayName + " TMS_Id:" + serviceToCheck.TMS_Id + "  Start type:"+ starttype/*+" TEST: "+test */);


                         
                        }
                       
                    }
                  
                }
                  
                await Task.Delay(CheckingRate, stoppingToken);
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
