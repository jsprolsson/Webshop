using System;

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

        
        public string Category
        {
            get { return category; }
            set
            {
                category = value.ToLower();
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
        public int Id
        {
            get { return id; }
            set
            {
                //if (true)
                //{
                //    //if value already exists within Products-list.item.id = Set first available id-number or default.
                //}
                id = value;
            }
        }


    }
    public class GroupBuy : Product
    {
        public int combined { get; set; }
        public string groupPrice { get; set; }


        // lägg till metod för att räkna ut pris. 
    }

}
