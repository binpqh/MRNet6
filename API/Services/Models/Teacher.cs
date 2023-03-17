using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Teacher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("birthday")]
        public string BirthDay { get; set; } = String.Empty;
        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; } = String.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;
        [BsonElement("delete")]
        public bool IsDelete { get; set; }
        [BsonElement("department")]
        public Dept Department { get; set; } = null!;
    }
    public class Dept
    {
        [BsonElement("name")]
        public string Name { get; set; } = null!;
    }    
}
