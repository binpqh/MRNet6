using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("code")]
        public string Code { get; set; } = String.Empty;
        [BsonElement("delete")]
        public bool IsDelete { get; set; } = false;
        [BsonElement("teacher")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId TeacherId { get; set; }
    }
}
