using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Webshop.Pages
{

    public class IndexModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products.Where(product => product.chosen).ToList();
        public static bool ReadCookie { get; set; }
        public string WelcomeText { get; set; }
        public bool SwedishAsLanguage { get; set; }
        public void OnGet()
        {
            Products = Products.Where(product => product.chosen).ToList();

            // Hämtar språk-cookie ifall det finns någon sparad och ställer användarens språk
            try
            {
                var swedish = JsonSerializer.Deserialize<string>(Request.Cookies["swedish"]);
                SwedishAsLanguage = Convert.ToBoolean(swedish);
            }
            catch (Exception)
            {
            }
            WelcomeText = SwedishAsLanguage ? "Välkommen till Megabörs!" : "Welcome to Megabörs!";

            // Hämtar cart-cookie första gången sidan öppnas för att fylla Cart med sparade artiklar - borttagen för att cookien blev större än 4kb
            //if (ReadCookie == true)
            //{
            //    Data.CartManager.RequestCookie(Request.Cookies["cart"]);
            //    ReadCookie = false;
            //}
        }

        public IActionResult OnPostLanguage(bool swedish)
        {
            // Skapar språk-cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("swedish", JsonSerializer.Serialize(Convert.ToString(swedish)), options);
            return RedirectToPage("/Index");
        }
    }
}
