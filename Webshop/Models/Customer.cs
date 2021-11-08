using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Customer
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Customer (string name, string email, string address)
        {
            this.name = name;
            this.email = email;
            this.address = address;
        }
    }
}
