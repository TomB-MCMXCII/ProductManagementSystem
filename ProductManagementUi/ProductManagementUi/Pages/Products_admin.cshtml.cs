using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Core;
using ProductManegement.Core.Models;

namespace ProductManagementUi.Pages
{
    public class Products_adminModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        public ICollection<Product> Products { get; set; }
        private IProductService _productService { get; set; }
 

        public Products_adminModel(IProductService productService)
        {
            _productService = productService;
            
        }
        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if(userId == null)
            {
                return RedirectToPage("./NotLogged");
            }
            Products = _productService.GetProducts();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                
                return Page();
            }
            else
            {
                var title = ModelState["Product.Title"].RawValue.ToString();
                var quantity = int.Parse(ModelState["Product.Quantity"].RawValue.ToString());
                var price = decimal.Parse(ModelState["Product.Price"].RawValue.ToString());
                _productService.AddProduct(title,quantity,price);

                return RedirectToPage("./Products_admin");

            }
        }

        public IActionResult OnPostDelete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToPage("./Products_admin");
        }

    }
}