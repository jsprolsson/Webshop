using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatchAPI = new Stopwatch();
            Stopwatch stopwatchThree = new Stopwatch();
            Stopwatch stopwatchCookie = new Stopwatch();


            stopwatchAPI.Start();
            Data.ProductManager.APICall();          // anropar API en gång vid start för att fylla utbudet
            stopwatchAPI.Stop();
            stopwatchThree.Start();
            Console.WriteLine("Stopwatch for API-method: " + stopwatchAPI.Elapsed);
            Data.ProductManager.ThreeChosen();      // sätter tre produkter som utvalda
            stopwatchThree.Stop();
            Console.WriteLine("Stopwatch for Three chosen-method: " + stopwatchThree.Elapsed);
            stopwatchCookie.Start();
            Pages.IndexModel.ReadCookie = true;     // används för att läsa in cookie en gång vid uppstart
            stopwatchCookie.Stop();
            Console.WriteLine("Stopwatch for Cookie-method: " + stopwatchCookie.Elapsed);
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
