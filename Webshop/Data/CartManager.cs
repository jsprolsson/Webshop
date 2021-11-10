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
            Cart.Remove(Cart[product.id]);
        }


    }
}
