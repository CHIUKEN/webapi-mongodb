using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonDBAPI.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }
        [BsonElement("ProductId")]
        public int ProductId { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("Price")]
        public int Price { get; set; }
        [BsonElement("CreateTime")]
        public DateTime CreateTime { get; set; }
        [BsonElement("Note")]
        public string Note { get; set; }
        [BsonElement("Buyer")]
        public Buyer Buyer { get; set; }
    }
}
