using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Responses
{
    public class AuthResponse
    {
        public bool Success { get; set; } = false;
        public string Role { get; set; } = null!;
        public string token { get; set; } = null!;
    }
    public class VerifyTokenResult
    {
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public string Role { get; set; } = null!;
        public RefreshToken TokenStored { get; set; } = null!;
    }
}
