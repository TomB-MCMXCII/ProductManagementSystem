using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Core;
using ProductManegement.Core.Models;

namespace ProductManagementUi.Pages
{
    public class EditProductModel : PageModel
    {
        private IProductService _productService { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        public EditProductModel(IProductService productService)
        {
            _productService = productService;

        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                var id = ModelState["Product.Id"].RawValue.ToString();
                var title = ModelState["Product.Title"].RawValue.ToString();
                var quantity = ModelState["Product.Quantity"].RawValue.ToString();
                var price = ModelState["Product.Price"].RawValue.ToString();

                _productService.Update(id, title, quantity, price);
                return RedirectToPage("./Products_admin");
            }
            return Page();
        }
       
    }
}