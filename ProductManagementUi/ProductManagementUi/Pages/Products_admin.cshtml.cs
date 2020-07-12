using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Core;
using ProductManegement.Core.Models;

namespace ProductManagementUi.Pages
{
    public class Products_adminModel : PageModel
    {
        [BindProperty]
        public AdminViewModel ViewModel { get; set; }
        private IProductService _productService { get; set; }
 

        public Products_adminModel(IProductService productService)
        {
            _productService = productService;
            ViewModel = new AdminViewModel();
        }
        public void OnGet()
        {
            ViewModel.Products = new List<Product>();
            ViewModel.Products = _productService.GetProducts();
        }

        public void OnPost()
        {
            if (ModelState.IsValid == false)
            {
                
            }
            else
            {
                var title = ModelState["ViewModel.Product.Title"].RawValue.ToString();
                var quantity = int.Parse(ModelState["ViewModel.Product.Quantity"].RawValue.ToString());
                var price = decimal.Parse(ModelState["ViewModel.Product.Price"].RawValue.ToString());
                _productService.AddProduct(title,quantity,price);
                ViewModel.Products = _productService.GetProducts();
            }
        }
       
    }
}