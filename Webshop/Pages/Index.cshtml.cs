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

        public int i = 0;
        public static bool ReadCookie { get; set; }
        [BindProperty]
        public string WelcomeText { get; set; }
        [BindProperty(SupportsGet =true)]
        public bool Svenska { get; set; }
        public void OnGet()
        {
            try
            {
                var language = JsonSerializer.Deserialize<string>(Request.Cookies["language"]);
                Svenska = Convert.ToBoolean(language);
            }
            catch (Exception)
            {

            }
            
            Products = Products.Where(product => product.chosen).ToList();
            if (ReadCookie == true)
            {
                Data.CartManager.RequestCookie(Request.Cookies["cart"]);
                //Data.CartManager.RequestCookie(HttpContext.Session.GetString("Cart"));
                ReadCookie = false;

                
            }
            WelcomeText = Svenska ? "Välkommen" : "Welcome";
        }

        public IActionResult OnPostLanguage(bool language)
        {
            // Skapar cookie
            string chosenLanguage = JsonSerializer.Serialize(Convert.ToString(language));
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("language", chosenLanguage, options);
            var cart = Request.Cookies["language"];
            return RedirectToPage("/Index");
        }

    }
}
