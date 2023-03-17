using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Responses
{
    public class StudentResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Age { get; set; } 
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Major { get; set; } = null!;
    }
}
