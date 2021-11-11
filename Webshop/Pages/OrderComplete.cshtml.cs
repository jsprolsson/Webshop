using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class OrderCompleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Models.Customer Customer { get; set; }

        public void OnGet()
        {
            
        }
    }
}
