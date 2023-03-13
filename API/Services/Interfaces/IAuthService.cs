using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest input);
        Task<string> GetMe(int id);
        Task ChangePasswod(int id, ChangePassword req);
    }
}
