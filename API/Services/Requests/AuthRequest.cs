using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Requests
{
    public class AuthLogin
    {
        [Required] public string Username { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }    
    public class AuthRequest
    {
        [Required] public string Id { get; set; } = null!;
        [Required] public string Username { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
        [Required] public string? Ipv4 { get; set; } = null!;
    }
    public class ChangePassword
    {
        [Required] public string OldPassword { get; set; } = null!;
        [Required] public string NewPassword { get; set; } = null!;
        [Required] public string ConfirmPassword { get; set; } = null!;
    }
}
