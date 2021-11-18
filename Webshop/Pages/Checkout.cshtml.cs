using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class CheckoutModel : PageModel
    {
        public List<Models.Order> orders = Models.Order.orders;
        public IEnumerable<IGrouping<string, Models.Product>> CartGroups = Data.CartManager.GroupCartByProducts();
        public List<Models.Product> Cart = Data.CartManager.Cart;
        public double Sum { get; set; }
        public double VAT { get; set; }
        public int Postage { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            foreach (var item in orders)
            {
                Postage = item.postage;
            }

            Sum = Data.CartManager.GetCartSum();
            VAT = Math.Round(Sum * 0.25, 0);
        }

        public void OnPostFinalize()
        {
            //vid köp så töms varukorgen.
            string message = Data.CartManager.EmptyCart();
            Message = message;
            
            // uppdaterar cart cookien så att den inte innehåller något
            string fullCart = JsonSerializer.Serialize(Cart);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("cart", fullCart, options);
        }
    }
}
