using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class CartModel : PageModel
    {
        public List<Models.Product> AllProducts = Data.ProductManager.Products;
        public List<Models.OrderItem> Cart = Data.CartManager.Cart;

        public double TotalSum { get; set; }

        public Models.Product Product { get; set; }



        public void OnGet(int id)
        {
            //If för att annars kraschar AddToCart-metoden för den inte får in något värde.
            if (id != 0)
            {
                //Tanken är här att man kan skicka in Index 0 i metoden för att det alltid bara köps en grej åt gången.
               AllProducts = AllProducts.Where(product => product.id == id).ToList();
                Data.CartManager.AddToCart(AllProducts[0]);
            }

            //GroupBy i listan för att sortera ut likadana produkter med samma id/namn och lägga på hög istället.
            //RemoveFromCart- & AddToCart-funktion kan vara knutna till knappar på view-page? Klicka på + -> 1 skickas till addtocart.  
        }

        //public void OnPostAdd()
        //{
        //    Data.CartManager.AddToCart();
        //}

        //public void OnPostRemove(int id)
        //{
        //    Data.CartManager.RemoveFromCart();
        //}
    }
}
