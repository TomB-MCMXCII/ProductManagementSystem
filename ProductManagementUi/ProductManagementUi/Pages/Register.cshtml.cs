using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManegement.Core.Interfaces.Services;
using ProductManegement.Core.Models;

namespace ProductManagementUi.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; }
        private IUserService _userService { get; set; }
        // todo: might not bet the best solution to check if user is added
        public bool UserAdded { get; set; }
        public void OnGet()
        {
            
        }
        public RegisterModel(IUserService userService)
        {
            _userService = userService;
            
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var email = ModelState["User.Email"].RawValue.ToString();
                var password = ModelState["User.Password"].RawValue.ToString();
                try
                {
                    //todo: if checkbox is checked returns string array [true, false];
                    var isAdmin = bool.Parse(ModelState["User.IsAdmin"].RawValue.ToString());
                    _userService.AddUser(email, password, false);
                    UserAdded = true;
                }
                catch
                {
                    _userService.AddUser(email, password, true);
                    UserAdded = true;
                }

                //return RedirectToPage("./Register");
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}