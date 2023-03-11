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
        public string Id { get; set; } = String.Empty;
        public string StudentId { get; set; } = String.Empty;
        public string SubjectId { get; set; } = String.Empty;
        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
