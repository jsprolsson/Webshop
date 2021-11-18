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
            //rensar carten för att inte skapa problem med existerande produkter i carten vid ändringar.
            //om produktens stock är 0 så skickar radio button för group iväg 0 till OnPostToGroup och returnerar då ett meddelande.
            //annars skickas hur många produkten användaren vill ha i en grupp till OnPostToGroup med Produktens ID, kallar på ToGroupSale-metoden.

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
