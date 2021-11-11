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
        public static List<Models.Product> ChosenProducts = new List<Models.Product>();
        //public static List<Models.SalesItem> SalesItems = new List<Models.SalesItem>();

        public static void APICall()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://fakestoreapi.com/products").GetAwaiter().GetResult();
            var apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Products = JsonSerializer.Deserialize<Models.Product[]>(apiResponse).ToList();
        }

        public static List<Models.Product> ThreeChosen()
        {
            List<Models.Product> ChosenProducts = Products;

            for (int i = 0; i < 3; i++)
            {
                ChosenProducts[i].chosen = true;
            }

            return ChosenProducts;
        }

        //public static void CreateSalesItems()
        //{
        //    List<Models.Product> sales = new List<Models.Product>();

        //}


    }
}
