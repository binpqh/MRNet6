using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("uid")]
        public string Uid { get; set; } = null!;
        [BsonElement("password")]
        public string Password { get; set; } = null!;
        [BsonElement("role")]
        public string Role { get; set; } = null!;
    }
}
