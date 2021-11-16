using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Data.ProductManager.APICall();          // anropar API en gång vid start för att fylla utbudet
            Data.ProductManager.ThreeChosen();      // sätter tre produkter som utvalda
            Pages.IndexModel.ReadCookie = true;     // används för att läsa in cookie en gång vid uppstart
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
