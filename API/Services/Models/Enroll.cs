using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Enroll
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("idStudent")]
        public ObjectId StudentId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("idSubject")]
        public ObjectId SubjectId { get; set; }
        [BsonElement("dateEnroll")]
        public DateTime DateEnroll { get; set; }
        [BsonElement("delete")]
        public bool IsDelete { get; set; } = false;
    }
}
