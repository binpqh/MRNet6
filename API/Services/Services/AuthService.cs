using MongoDB.Driver;
using Services.Interfaces;
using Services.Models;
using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMongoCollection<Account> _accountCollection;
        private readonly ITokenService _tokenService;
        public AuthService(IMongoDbContext context, ITokenService tokenService) {
            _tokenService = tokenService;
            _accountCollection = context.GetCollection<Account>("Account");
        }
        public Task ChangePasswod(int id, ChangePassword req)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMe(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> Login(AuthRequest input)
        {
            var acc = await _accountCollection.Find(a => a.Uid == input.Username).FirstOrDefaultAsync();
            if (acc == null)
            {
                throw new Exception("Người dùng không tồn tại");
            }
            if (acc.Password.Replace(" ", "") != input.Password)
            {
                throw new Exception("Mật khẩu không đúng");
            }
            var token = await _tokenService.GenarateToken(new AuthRequest()
            {
                Username = input.Username,
                Ipv4 = input.Ipv4,
                Id = acc.Uid.ToString(),

            });
            return token;
        }
    }
}
