using MonDBAPI.Interfaces;
using MonDBAPI.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonDBAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbContext _db;
        public ProductRepository(MongoDbContext db)
        {
            _db = db;
        }

        public Response<Product> AddProdcut(Product p)
        {
            var result = new Response<Product>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.Create(p);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Response<bool> DeleteProduct(string Id)
        {
            var result = new Response<bool>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.Remove(objId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Response<IEnumerable<Product>> FindAll(string email)
        {
            var result = new Response<IEnumerable<Product>>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.GetProductsByEmail(email);
            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public Response<IEnumerable<Product>> GetAll()
        {
            var result = new Response<IEnumerable<Product>>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.GetProducts();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Response<Product> GetProductById(string Id)
        {
            var result = new Response<Product>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.GetProduct(objId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Response<bool> UpdateProduct(string Id, Product p)
        {
            var result = new Response<bool>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.Update(objId, p);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
