using ProductManegement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();
        void AddProduct(string title, int quantity, decimal price);
        void DeleteProduct(int id);
        Product GetById(int id);
        void Update(string id, string title, string quantity, string price);
    }
}