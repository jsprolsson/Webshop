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
        public static List<Models.GroupSale> GroupSales = new List<Models.GroupSale>();

        public static void APICall()
        {
            //kallar in produkterna från fake store-api:t och lägger till i products-listan.

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://fakestoreapi.com/products").GetAwaiter().GetResult();
            var apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Products = JsonSerializer.Deserialize<Models.Product[]>(apiResponse).ToList();

            foreach (var item in Products)
            {
                item.price = Math.Round(item.price, 0);
            }
        }

        public static void ThreeChosen()    
        {
            // väljer ut tre produkter som ska visas på startsidan

            List<Models.Product> ChosenProducts = Products;

            for (int i = 0; i < 3; i++)
            {
                ChosenProducts[i].chosen = true;
            }

        }
        public static int GetRandomStock() 
        {
            //returnerar en slumpmässigt siffra till produkternas lagersaldo när dem kallas in från API:t.

            Random rand = new Random();
           return rand.Next(10, 100);
        }

        public static void RemoveFromStock()
        {
            //Beroende på antalet som köps av produkten i Cart vid checkout, så tas samma antal bort från lagersaldot.

            IEnumerable<IGrouping<string, Models.Product>> CartGroups = CartManager.GroupCartByProducts();

            foreach (var group in CartGroups)
            {
                foreach (var item in group)
                {
                        item.stock -= 1;
                }
            }
        }
        public static List<Models.Product> GetCategory(string category)
        {
            // den utvalda kategorins produkter returneras

            List<Models.Product> products = new List<Models.Product>();
            return products = Products.Where(product => product.category == category).ToList();
        }
        public static List<Models.Product> GetGroupCategory(string category)
        {
            // alla group sales har "GROUP DISCOUNT" tillagd i titeln. Metoden returnerar en lista
            List<Models.Product> products = new List<Models.Product>();
            return products = Products.Where(product => product.title.Contains("GROUP DISCOUNT")).Select(product => product).ToList();
        }

        public static List<Models.Product> SearchForProduct(string search)
        {
            //metod som kallas när användaren söker. sökmeddelandet går igenom category, title och description.

            if (search != null)
            {
                List<Models.Product> products = new List<Models.Product>();
                search = search.ToLower();
                return products = Products.Where(product => product.category.ToLower().Contains(search) || product.title.ToLower().Contains(search) || product.description.ToLower().Contains(search)).Select(product => product).ToList();
            }
            else return Products;
            
        }

        public static List<Models.GroupSale> SearchForGroupProduct(string search)
        {
            //söker igenom group sale-produkterna efter parametern search i category, title och description.

            if (search != null)
            {
                List<Models.GroupSale> products = new List<Models.GroupSale>();
                search = search.ToLower();
                return products = GroupSales.Where(product => product.category.ToLower().Contains(search) || product.title.ToLower().Contains(search) || product.description.ToLower().Contains(search)).Select(product => product).ToList();
            }
            else return GroupSales;
        }

        public static void ProductToGroupSale(int productID, int groupSize)
        {
            //hittar nästa tillgängliga id, hittar produkten som ska göras till group sale med linq. produkten läggs till som groupsale i Products-listan.

            int nextId = Products.Count + 1;
            List<Models.Product> products = Products.Where(product => product.id == productID).ToList();
            Products.Add(new Models.GroupSale(nextId, products[0].title, products[0].price, products[0].description, products[0].category, products[0].image, products[0].chosen, products[0].stock, groupSize));
        }

        public static void AddProduct(Models.Product product)
        {
            //nextId räknar hur många produkter som finns och hittar nästa tillgängliga id.
            //lägger sedan till produkten som den får in som ny i Products-listan.

            int nextId = Products.Count + 1;
            Products.Add(new Models.Product(nextId, product.title, product.price, product.description, product.category, product.image, product.chosen, product.stock));
        }

        public static void ChangeProduct(Models.Product Product)
        {
            //tar in en product med properties, hittar indexet produkten som ändras låg på, ersätter den och lägger till den nya produkten.

            int index = Products.FindIndex(product => product.id == Product.id);
            Products.RemoveAt(index);
            Products.Insert(index, Product);
        }
    }
}
