using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Order
    {
        public static List<Order> orders = new List<Order>();
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string address { get; set; }
        public int postage { get; set; }
        public string paymentMethod { get; set; }

        public Order(string name, string email, string address)
        {
            this.name = name;
            this.email = email;
            this.address = address;
        }

        public Order()
        {
        }
    }
}
