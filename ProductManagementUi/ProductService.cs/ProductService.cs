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
        private int vat = 21;

        public ProductService(IProductManagementDbContext context)
        {
            _context = context;
        }

        public ICollection<KeyValuePair<Product, decimal>> GetProducts()
        {
            var products = _context.Products.OrderBy(x => x.Id);
            
            var dict = new Dictionary<Product, decimal>();

            foreach (var p in products)
            {
                var vat = CalculateTotalPriceWithVat(p.Price,p.Quantity);
                dict.Add(p, vat);
            }
            return dict;
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

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }
        public void Update(string id, string title, string quantity, string price)
        {
            var product = _context.Products.Find(int.Parse(id));
            product.Title = title;
            product.Quantity = int.Parse(quantity);
            product.Price = decimal.Parse(price);

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public decimal CalculateTotalPriceWithVat(decimal price,int amount)
        {
            return (price * amount) * (1 + vat);
        }

    }
}
