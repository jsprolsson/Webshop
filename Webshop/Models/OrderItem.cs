using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Tax { get; set; }

        public OrderItem(Product product, int amount)
        {
            this.Product = product;
            this.Amount = amount;
            this.Tax = product.price * 0.25;
        }
    }
}
