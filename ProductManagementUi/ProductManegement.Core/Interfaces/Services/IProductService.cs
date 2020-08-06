using ProductManegement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core
{
    public interface IProductService
    {
        ICollection<KeyValuePair<Product,decimal>> GetProducts();
        void AddProduct(string title, int quantity, decimal price);
        void DeleteProduct(int id);
        Product GetById(int id);
        void Update(string id, string title, string quantity, string price);
        decimal CalculateTotalPriceWithVat(decimal price, int amount);
    }
}