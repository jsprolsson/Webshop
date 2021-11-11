using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Data
{
    public class CartManager
    {
        public static List<Models.OrderItem> Cart = new List<Models.OrderItem>();

        public static void AddToCart(Models.Product product)
        {
            Cart.Add(new Models.OrderItem(product, 1));
        }

        public static void RemoveFromCart(Models.Product product)
        {
            int index = Cart.FindIndex(Product => Product.Product.id == product.id);
            Cart.RemoveAt(index);
        }

        public static double GetCartSum()
        {
            double sum = 0;

            foreach (var product in Cart)
            {
                sum += product.Product.price;
            }

            return Math.Round(sum, 2);
        }

        public static int GetShippingCost(Models.Customer customer)
        {
            int shipping = 0;

            if (customer.country == "Sweden")
            {
                shipping = 49;
            }
            else 
            {
                shipping = 99;
            }

            return shipping;
        }

        public static IEnumerable<IGrouping<string, Models.OrderItem>> GroupCartByProducts()
        {
            IEnumerable<IGrouping<string, Models.OrderItem>> CartGroups;

            CartGroups = Cart.GroupBy(product => product.Product.title).OrderBy(product => product.Key);

            return CartGroups;
        }

    }
    public enum ShippingAlternatives
    {
        Postnord,
        DHL
    }
}
