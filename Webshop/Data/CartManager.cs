using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Data
{
    public class CartManager
    {
        public static List<Models.Product> Cart = new List<Models.Product>();

        public static void AddToCart(Models.Product product)
        {
            Cart.Add(product);
        }

        public static void RemoveFromCart(Models.Product product)
        {
            int index = Cart.FindIndex(Product => Product.id == product.id);
            Cart.RemoveAt(index);
        }

        public static double GetCartSum()
        {
            double sum = 0;

            foreach (var product in Cart)
            {
                sum += product.price;
            }

            return Math.Round(sum, 2);
        }

        public static IEnumerable<IGrouping<string, Models.Product>> GroupCartByProducts()
        {
            IEnumerable<IGrouping<string, Models.Product>> CartGroups;

            CartGroups = Cart.GroupBy(product => product.title);

            return CartGroups;
        }

        public static string EmptyCart()
        {
            ProductManager.RemoveFromStock();
            Cart.Clear();
            Models.Order.orders.Clear();
            return "Thank you for the order!";
        }

    }
    public enum ShippingAlternatives
    {
        Postnord = 6,
        DHL = 9
    }
}
