using ProductManagement.Core;
using ProductManagement.Repository;
using ProductManegement.Core.Interfaces;
using ProductManegement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void AddProduct(string title, int quantity, decimal price)
        {
            var product = new Product()
            {
                Title = title,
                Quantity = quantity,
                Price = price
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
