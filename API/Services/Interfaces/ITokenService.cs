using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        Task<AuthResponse> GenarateToken(AuthRequest authRequest);
        Task<AuthResponse> GenarateRefreshToken(string token, string? ipV4);
    }
}
