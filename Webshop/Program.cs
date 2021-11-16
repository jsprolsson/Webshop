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
            Data.ProductManager.APICall();          // anropar API en g�ng vid start f�r att fylla utbudet
            Data.ProductManager.ThreeChosen();      // s�tter tre produkter som utvalda
            Pages.IndexModel.ReadCookie = true;     // anv�nds f�r att l�sa in cookie en g�ng vid uppstart
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
