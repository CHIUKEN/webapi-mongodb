using MonDBAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonDBAPI
{
    public class MongoDbContext
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public MongoDbContext()
        {
            _client = new MongoClient("Your Mongodb Connectstring");
            _server = _client.GetServer();
            _db = _server.GetDatabase("learn");
        }
        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("Products").FindAll();
        }

        public Product GetProduct(ObjectId id)
        {
            var res = Query<Product>.EQ(p => p.Id, id);
            //var res = Query<Product>.EQ(p => p.Buyer.Email, "test@gmail.com");
            return _db.GetCollection<Product>("Products").FindOne(res);
        }

        public IEnumerable<Product> GetProductsByEmail(string Email)
        {
            var res = Query<Product>.EQ(p => p.Buyer.Email, Email);
            return _db.GetCollection<Product>("Products").Find(res);
        }

        public Product Create(Product p)
        {
            _db.GetCollection<Product>("Products").Save(p);
            return p;
        }

        public bool Update(ObjectId id, Product p)
        {
            p.Id = id;
            var res = Query<Product>.EQ(pd => pd.Id, id);
            var operation = Update<Product>.Replace(p);
            var result = _db.GetCollection<Product>("Products").Update(res, operation);
            return !result.HasLastErrorMessage;
        }

        public bool Remove(ObjectId id)
        {
            var res = Query<Product>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Product>("Products").Remove(res);
            return !operation.HasLastErrorMessage;
        }
    }
}
