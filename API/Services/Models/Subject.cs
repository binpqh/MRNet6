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
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public string TeacherId { get; set; } = String.Empty;

        public virtual Teacher Teacher { get; set; } = null!;
    }
}
