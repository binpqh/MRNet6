using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;
        [BsonElement("phone")]
        public string Phone { get; set; } = String.Empty;
        [BsonElement("address")]
        public string Address { get; set; } = String.Empty;
        [BsonElement("major")]
        public string Major { get; set; } = String.Empty;
        [BsonElement("delete")]
        public bool IsDelete { get; set; } = false;
    }
}
