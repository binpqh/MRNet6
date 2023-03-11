using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Responses
{
    public class TeacherResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Birthday { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
    }
}
