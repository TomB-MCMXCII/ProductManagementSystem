using ProductManagement.Core;
using ProductManagement.Repository;
using ProductManegement.Core.Interfaces;
using ProductManegement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Core
{
    public class ProductService : IProductService
    {
        private IProductManagementDbContext _context;

        public ProductService(IProductManagementDbContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetProducts()
        {
            var products = _context.Products.OrderBy(x => x.Id);
            return products.ToList<Product>();
        }
    }
}
