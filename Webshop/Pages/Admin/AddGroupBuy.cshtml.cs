using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages.Admin
{
    public class AddGroupBuyModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products;

        [BindProperty]
        public int ProductID { get; set; }
        [BindProperty]
        public int GroupSize { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPostToGroup()
        {
            //rensar carten f�r att inte skapa problem med existerande produkter i carten vid �ndringar.
            //om produktens stock �r 0 s� skickar radio button f�r group iv�g 0 till OnPostToGroup och returnerar d� ett meddelande.
            //annars skickas hur m�nga produkten anv�ndaren vill ha i en grupp till OnPostToGroup med Produktens ID, kallar p� ToGroupSale-metoden.

            Data.CartManager.EmptyCart();
            if (ProductID != 0)
            {
                Data.ProductManager.ProductToGroupSale(ProductID, GroupSize);
            }
            else
            {
                Message = "Item is not in stock!";
            }
        }
    }
}
