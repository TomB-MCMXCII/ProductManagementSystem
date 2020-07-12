using ProductManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManegement.Core.Models
{
    public class AdminViewModel
    {
        public Product Product { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
