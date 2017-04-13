using MonDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonDBAPI.Interfaces
{
    public interface IProductRepository
    {
        Response<Product> AddProdcut(Product p);
        Response<IEnumerable<Product>> GetAll();
        Response<bool> DeleteProduct(string Id);
        Response<Product> GetProductById(string Id);
        Response<bool> UpdateProduct(string Id, Product p);
        Response<IEnumerable<Product>> FindAll(string email);
    }
}
