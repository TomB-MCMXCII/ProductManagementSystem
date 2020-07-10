using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Core;
using ProductManegement.Core.Models;


namespace ProductManagementUi.Pages
{
    public class ProductsModel : PageModel
    {
        public ICollection<Product> Products { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        private IProductService _productService { get; set; }

        public ProductsModel(IProductService productService)
        {
            _productService = productService;
        }
        public void OnGet()
        {
           Products =  _productService.GetProducts();
        }
    }
}