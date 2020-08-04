using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductManagementUi.Pages
{
    public class NotLoggedModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}