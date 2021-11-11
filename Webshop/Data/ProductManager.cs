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


        public static void TestGroupBuy() //enbart för test
        {
            //Products.Add(new Models.GroupBuy(Products.Count + 1, "GroupBuy", 299, "3 groups", "Jeans", "https://media.campadre.com/3F1DE1FC29E88D65C0E4BB8A83A6F64C.jpg/w580/h725/r1.25/?optimizer=image", false, 10, 3));
        }

        //public static void CreateSalesItems()
        //{
        //    List<Models.Product> sales = new List<Models.Product>();

        //}



    }
}
