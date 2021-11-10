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
        public int stock { get; set; }

        //public Product(int id, string title, double price, string description, string category, string image, bool chosen, int stock)
        //{
        //    this.id = id;
        //    this.title = title;
        //    this.price = price;
        //    this.description = description;
        //    this.category = category;
        //    this.image = image;
        //    this.chosen = chosen;
        //    this.stock = 100;
        //}

        

    }
    //public class GroupBuy : Product
    //{
    //    public int Combined { get; set; }
    //    public string GroupPrice { get; set; }

    //    public GroupBuy(int id, string title, double price, string description, string category, string image, bool chosen, int stock, int combined): base(id,  title,  price,  description,  category,  image,  chosen,  stock)
    //    {
    //        this.id = id;
    //        this.title = title;
    //        this.price = price * 3;
    //        this.description = "Group Buy";
    //        this.category = category;
    //        this.image = image;
    //        this.chosen = chosen;
    //        this.stock = 100;
    //        this.Combined = combined;
    //    }
    //}

        

}
