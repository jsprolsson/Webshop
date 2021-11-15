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

        public static void ThreeChosen()
        {
            List<Models.Product> ChosenProducts = Products;

            for (int i = 0; i < 3; i++)
            {
                ChosenProducts[i].chosen = true;
            }

        }
        public static int GetRandomStock()
        {
            Random rand = new Random();
           return rand.Next(1, 100);
        }

        public static void RemoveFromStock()
        {
            IEnumerable<IGrouping<string, Models.OrderItem>> CartGroups = CartManager.GroupCartByProducts();

            foreach (var group in CartGroups)
            {
                foreach (var item in group)
                {
                        item.Product.stock -= 1;
                }
            }
        }

        public static List<Models.Product> SearchForProduct(string search)
        {
            List<Models.Product> products = new List<Models.Product>();

            search = search.ToLower();
            return products = Products.Where(product => product.category.ToLower().Contains(search) || product.title.ToLower().Contains(search) || product.description.ToLower().Contains(search)).Select(product => product).ToList();
        }

        public static List<Models.Product> Categories(string category)
        {
            List<Models.Product> products = new List<Models.Product>();
            return products = Products.Where(product => product.category == category).ToList();
            
        }


        public static void ProductToGroup(int itemID)
        {
            Products.Add(new Models.GroupBuy());
        }

        



    }
}
