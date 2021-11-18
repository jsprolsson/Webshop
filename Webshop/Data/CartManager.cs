using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Webshop.Data
{
    public class CartManager
    {
        public static List<Models.Product> Cart = new List<Models.Product>();

        public static void AddToCart(Models.Product product)
        {
            //lägger till i cart.

            Cart.Add(product);
        }

        public static void RemoveFromCart(Models.Product product)
        {
            //tar bort produkten utifrån index.

            int index = Cart.FindIndex(Product => Product.id == product.id);
            Cart.RemoveAt(index);
        }

        public static double GetCartSum()
        {
            //räknar ihop summan av alla produkter i cart. rundar siffran till två decimaler innan den returneras.

            double sum = 0;

            foreach (var product in Cart)
            {
                sum += product.price;
            }

            return Math.Round(sum, 1);
        }

        public static IEnumerable<IGrouping<string, Models.Product>> GroupCartByProducts()
        {
            //metoden grupperar produkterna i carten utifrån title och lägger produkterna i ordning enligt keysen.

            IEnumerable<IGrouping<string, Models.Product>> CartGroups;
            CartGroups = Cart.GroupBy(product => product.title).OrderBy(product => product.Key);

            return CartGroups;
        }


        public static void RequestCookie(string cartCookie)
        {
            try
            {
                Cart = JsonSerializer.Deserialize<Models.Product[]>(cartCookie).ToList();
            }
            catch (Exception)
            {
            }
        }


        public static string EmptyCart()
        {
            //tömmer varukorgen och listan med order-info när någon köper. returnerar en sträng.

            ProductManager.RemoveFromStock();
            Cart.Clear();
            Models.Order.orders.Clear();
            return "Thank you for the order!";
        }

    }
    public enum ShippingAlternatives
    {
        //fraktalternativ med int kopplade för att bestämma priset för dem.

        Postnord = 69,
        DHL = 99
    }
}
