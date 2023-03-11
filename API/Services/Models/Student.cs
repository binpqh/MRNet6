using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.Models
{
    public class Student
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Age { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Major { get; set; } = String.Empty;
    }
}
