using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace SampleWebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void Trigger([EventHubTrigger("hub-private")] EventData message)
        {
            string data = Encoding.UTF8.GetString(message.GetBytes());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Message received. Data: '{data}'");
            Console.ResetColor();
        }
    }
}
