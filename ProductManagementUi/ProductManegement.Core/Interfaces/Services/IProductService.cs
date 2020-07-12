using ProductManegement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();
        void AddProduct(string title, int quantity, decimal price);
    }
}