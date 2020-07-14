using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Core;
using ProductManegement.Core.Models;

namespace ProductManagementUi.Pages
{
    public class Products_adminModel : PageModel
    {
        [BindProperty]
        public AdminViewModel ViewModel { get; }
        private IProductService _productService { get; set; }
 

        public Products_adminModel(IProductService productService)
        {
            _productService = productService;
            ViewModel = new AdminViewModel();
            ViewModel.Products = _productService.GetProducts();
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                
                return Page();
            }
            else
            {
                var title = ModelState["ViewModel.Product.Title"].RawValue.ToString();
                var quantity = int.Parse(ModelState["ViewModel.Product.Quantity"].RawValue.ToString());
                var price = decimal.Parse(ModelState["ViewModel.Product.Price"].RawValue.ToString());
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