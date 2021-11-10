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
        public Models.Product Product { get; set; }



        public void OnGet(int id)
        {
            //If f�r att annars kraschar AddToCart-metoden f�r den inte f�r in n�got v�rde.
            if (id != 0)
            {
                //Tanken �r h�r att man kan skicka in Index 0 i metoden f�r att det alltid bara k�ps en grej �t g�ngen.
               AllProducts = AllProducts.Where(product => product.id == id).ToList();
                Data.CartManager.AddToCart(AllProducts[0]);
            }

            //GroupBy i listan f�r att sortera ut likadana produkter med samma id/namn och l�gga p� h�g ist�llet.
            //RemoveFromCart- & AddToCart-funktion kan vara knutna till knappar p� view-page? Klicka p� + -> 1 skickas till addtocart.  
            

        }
    }
}
