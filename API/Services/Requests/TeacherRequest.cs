using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Requests
{
    public class TeacherRequest
    {
        [Required] public string name { get; set; } = null!;
        [Required] public Dept department { get;set; } = null!;
        [Required] public string email { get;set; } = null!;
        [Required] public string BirthDay { get; set; } = null!;
        [Required] public string PhoneNumber { get; set; } = null!;

    }
}
