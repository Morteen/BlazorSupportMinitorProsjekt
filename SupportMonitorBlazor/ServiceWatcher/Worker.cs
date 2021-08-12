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

namespace ServiceWatcher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        ServiceController[] scServices;
      

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var ServiceDisplayName = _config.GetSection("TmsInfo:ServiceDisplayName").Get<string[]>();
            while (!stoppingToken.IsCancellationRequested)
            {
                scServices = ServiceController.GetServices();
                foreach (ServiceController scTemp in scServices)
                {
                    foreach(string name in ServiceDisplayName) { 
                    if (scTemp.ServiceName == name)
                    {
                        Console.WriteLine("Service Navn:"+ scTemp.DisplayName+"  Status " + scTemp.Status);
                    }
                    }
                }
                     //   _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
