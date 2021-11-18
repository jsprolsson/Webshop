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
            //vi upplevde att sidan tog l�ng tid p� sig att ladda. Kollade tiderna med stopwatches, en f�r var metod vi kallade p�.
            //m�rkte inga st�rre skillnader mellan g�ngerna. kan ha varit n�r vi laddade in api:n g�ng p� g�ng att den tog l�ngre tid p� sig att svara.

            Stopwatch stopwatchAPI = new Stopwatch();
            Stopwatch stopwatchThree = new Stopwatch();
            Stopwatch stopwatchCookie = new Stopwatch();


            stopwatchAPI.Start();
            Data.ProductManager.APICall();          // anropar API en g�ng vid start f�r att fylla utbudet
            stopwatchAPI.Stop();

            stopwatchThree.Start();
            Console.WriteLine("Stopwatch for API-method: " + stopwatchAPI.Elapsed);
            Data.ProductManager.ThreeChosen();      // s�tter tre produkter som utvalda
            stopwatchThree.Stop();

            Console.WriteLine("Stopwatch for Three chosen-method: " + stopwatchThree.Elapsed);
            stopwatchCookie.Start();
            //Pages.IndexModel.ReadCookie = true;     // anv�ndes f�r att l�sa in cart-cookie vid uppstart men vi uppt�ckte att cookie-filen snabbt blev 4kb stor vilket �r gr�nsen s� vi valde att ta bort detta
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
