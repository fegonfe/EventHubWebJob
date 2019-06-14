using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.WebJobs.Logging;
using System.Configuration;

namespace SampleWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            string eventHubName = ConfigurationManager.AppSettings["EventHubName"];
            string eventHubConnectionString = ConfigurationManager.AppSettings["EventHubConnectionString"];

            var eventHubConfig = new EventHubConfiguration();
            
            eventHubConfig.AddReceiver(eventHubName, eventHubConnectionString);

            config.UseEventHub(eventHubConfig);

            using (var host = new JobHost(config))
            { 
                // The following code ensures that the WebJob will be running continuously
                host.RunAndBlock();
            }
        }
    }
}
