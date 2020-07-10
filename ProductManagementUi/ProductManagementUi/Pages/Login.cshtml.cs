using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductManegement.Core.Interfaces.Services;
using ProductManegement.Core.Models;

namespace ProductManagementUi.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; }
        private IUserService _userService { get; set; }
        public void OnGet()
        {
            _userService.CheckDefaultAdmin();
        }
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            else
            {
                var email = ModelState["User.Email"].RawValue.ToString();
                var password = ModelState["User.Password"].RawValue.ToString();

                if (_userService.UserExists(email, password))
                {
                    if (_userService.IsAdmin(email, password))
                    {
                        return RedirectToPage("./Products_admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("","User does not exist");
                    return Page();
                }
                
                return RedirectToPage("./Products");
            }
        }
       
    }
}