using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Webshop.Data
{
    public class ProductManager
    {
        public static List<Models.Product> Products = new List<Models.Product>();

        public static List<Models.Product> GetProducts()
        {
            List<Models.Product> products = new List<Models.Product>();

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://fakestoreapi.com/products").GetAwaiter().GetResult();
            var apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return products = JsonSerializer.Deserialize<Models.Product[]>(apiResponse).ToList();
        }

    }
}
