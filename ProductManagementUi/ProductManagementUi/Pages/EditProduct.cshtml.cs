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
       
    }
}