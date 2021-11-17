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
        public static List<Models.GroupSale> GroupBuyItems = new List<Models.GroupSale>();

        public static void APICall()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://fakestoreapi.com/products").GetAwaiter().GetResult();
            var apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Products = JsonSerializer.Deserialize<Models.Product[]>(apiResponse).ToList();
        }

        public static void ThreeChosen()    // väljer ut tre produkter som ska visas på startsidan
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
           return rand.Next(10, 100);
        }

        public static void RemoveFromStock()
        {
            IEnumerable<IGrouping<string, Models.Product>> CartGroups = CartManager.GroupCartByProducts();

            foreach (var group in CartGroups)
            {
                foreach (var item in group)
                {
                        item.stock -= 1;
                }
            }
        }

        public static List<Models.Product> SearchForProduct(string search)
        {
            if (search != null)
            {
                List<Models.Product> products = new List<Models.Product>();
                search = search.ToLower();
                return products = Products.Where(product => product.category.ToLower().Contains(search) || product.title.ToLower().Contains(search) || product.description.ToLower().Contains(search)).Select(product => product).ToList();
            }
            else return Products;
            
        }

        public static List<Models.Product> Categories(string category)
                {
                    List<Models.Product> products = new List<Models.Product>();
                    return products = Products.Where(product => product.category == category).ToList();
                }

        public static List<Models.GroupSale> SearchForGroupProduct(string search)
        {
          
            List<Models.GroupSale> products = new List<Models.GroupSale>();

            if (search != null)
            {
                List<Models.GroupBuy> products = new List<Models.GroupBuy>();
                search = search.ToLower();
                return products = GroupBuyItems.Where(product => product.category.ToLower().Contains(search) || product.title.ToLower().Contains(search) || product.description.ToLower().Contains(search)).Select(product => product).ToList();
            }
            else return GroupBuyItems;
        }

        public static List<Models.GroupSale> GroupCategories(string category)
        {
            List<Models.GroupSale> products = new List<Models.GroupSale>();
            return products = GroupBuyItems.Where(product => product.category == category).ToList();
        }

        public static void ProductToGroupSale(int productID, int groupSize)
        {
            int nextId = Products.Count + 1;
            List<Models.Product> products = Products.Where(product => product.id == productID).ToList();
            Products.Add(new Models.GroupSale(nextId, products[0].title, products[0].price, products[0].description, products[0].category, products[0].image, products[0].chosen, products[0].stock, groupSize));
        }

        public static void AddProduct(Models.Product product)
        {
            int nextId = Products.Count + 1;
            Products.Add(new Models.Product(nextId, product.title, product.price, product.description, product.category, product.image, product.chosen, product.stock));
        }

        public static void ChangeProduct(Models.Product Product)
        {
            int index = Products.FindIndex(product => product.id == Product.id);
            Products.RemoveAt(index);
            Products.Insert(index, Product);
        }
    }
}
