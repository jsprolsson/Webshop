using System;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public bool chosen { get; set; }
        
        public int stock = Data.ProductManager.GetRandomStock();

        public Product()
        {

        }
        
        public Product(int id, string title, double price, string description, string category, string image, bool chosen, int stock)
        {
            this.id = id;
            this.title = title;
            this.price = price;
            this.description = description;
            this.category = category;
            this.image = image;
            this.chosen = chosen;
            this.stock = stock;

        }

        public string Category
        {
            get { return category; }
            set
            {
                if (category != null)
                {
                    category = value.ToLower();
                }
                else
                {
                    category = value;
                }

            }
        }
        public int Stock
        {
            get { return stock; }

            set
            {
                if (value <= 100 && value >= 0 )
                {
                    stock = value;
                }
                else
                {
                    stock = 100;

                }
            }

        }
    }


    public class GroupSale : Product
    {
        public int groupSize { get; set; }
        public double originalPriceForGroup { get; set; }
        public double salePercentage = 0.75;

        public GroupSale(int id, string title, double price, string description, string category, string image, bool chosen, int stock, int groupSize)
        {

            this.id = id;
            this.title = $"GROUP DISCOUNT {title}";
            this.price = Math.Round((price * groupSize) * salePercentage, 1);
            this.description = description;
            this.category = category;
            this.image = image;
            this.chosen = false;
            this.stock = 5;
            this.groupSize = groupSize;
            originalPriceForGroup = price * groupSize;

        }

    }

}
