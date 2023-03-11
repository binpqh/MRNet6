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
        public Teacher() {
            Subjects = new HashSet<Subject>();
        }
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string BirthDay { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string DepartmentId { get; set; } = String.Empty;
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
