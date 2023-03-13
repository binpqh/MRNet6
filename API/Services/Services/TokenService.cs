using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Interfaces;
using Services.Models;
using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _securityKey;
        private readonly IMongoCollection<Account> _account;
        private readonly IMongoCollection<RefreshToken> _token;
        public TokenService(IConfiguration configuration, SymmetricSecurityKey securityKey, IMongoDbContext context)
        {
            _configuration = configuration;
            _securityKey = securityKey;
            _account = context.GetCollection<Account>("Account");
            _token = context.GetCollection<RefreshToken>("Token");
        }

        public async Task<AuthResponse> GenarateToken(AuthRequest authRequest)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.NameId, authRequest.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, authRequest.Username),
        };

            var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();


            // Create the JWT security token and encode it.
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            //Create Refresh Token
            var refreshToken = new RefreshToken()
            {
                IpAddress = authRequest.Ipv4,
                JwtTokenId = token.Id,
                RefreshTokenString = RandomString(25) + Guid.NewGuid(),
                UserId = authRequest.Username,
            };
            await _token.InsertOneAsync(refreshToken);
            //Get current user role
            var roleuser = _account.AsQueryable()
                .Where(a => a.Uid == authRequest.Username)
                .Select(a => a.Role)
                .FirstOrDefault();
            if(roleuser != null)
            {
            return new AuthResponse()
            {
                token = jwtToken,
                Success = true,
                Role = roleuser
            };
            }
            else
            {
                throw new Exception("Người dùng không có bất kì quyền nào");
            }    
        }
        private static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<AuthResponse> GenarateRefreshToken(string token, string? ipV4)
        {
            var verifyToken = await VerifyToken(token, ipV4);
            if (verifyToken == null) throw new Exception("Token refresh is null");
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.NameId, verifyToken.UserId),
            new Claim(JwtRegisteredClaimNames.UniqueName, verifyToken.Username),
            new Claim("Ip", verifyToken.IpAddress)
            };

            var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = creds
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();


            // Create the JWT security token and encode it.
            var jwtToken = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(jwtToken);
            verifyToken.TokenStored.JwtTokenId = jwtToken.Id;
            // Khúc này tìm thg collection của token đó vào update nó lại nè
            var update = Builders<RefreshToken>.Update.Set(m=> m.JwtTokenId, jwtToken.Id);
            var filter = await _token.UpdateOneAsync(t => t.Id == verifyToken.TokenStored.Id, update);
            return new AuthResponse()
            {
                Success = true,
                token = accessToken,
                Role = verifyToken.Role,
            };
        }
        private async Task<VerifyTokenResult> VerifyToken(string token, string? ipV4)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenReader = jwtTokenHandler.ReadJwtToken(token);
            if (tokenReader == null) throw new Exception("Can not read this Token");
            //var storedRefreshToken =
            //    await _context.RefreshTokens.FirstOrDefaultAsync(x => x.JwtTokenId == tokenReader.Id);
            var tokenStored = await _token
                .Find(t => t.JwtTokenId == tokenReader.Id)
                .FirstOrDefaultAsync();
            if (tokenStored == null) throw new Exception("Token is invalid");

            // Check ip v4
            if (tokenStored.IpAddress != ipV4) throw new Exception("Token is invalid");
            var user = await _account.Find(x=>x.Uid == tokenStored.UserId.Replace(" ", ""))
                .FirstOrDefaultAsync();
            if (user == null) throw new Exception("Token is invalid");

            return new VerifyTokenResult()
            {
                Username = tokenReader.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.UniqueName)!.Value,
                IpAddress = ipV4 ?? String.Empty,
                UserId = tokenStored.UserId,
                TokenStored = tokenStored,
                Role = user.Role,
            };
        }
    }
}
