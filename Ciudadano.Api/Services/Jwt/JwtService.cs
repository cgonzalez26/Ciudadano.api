using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Ciudadano.Api.Services.Jwt
{
    public class JwtService
    {
        private static JwtService _instance;

        public JwtService()
        {
        }

        public static JwtService Instance => _instance ?? (_instance = new JwtService());

        public string GetToken(dynamic user, string secretKey, int expiresInDays)
        {
            if (user == null || string.IsNullOrEmpty(secretKey) || expiresInDays < 1) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim("UserName", user.UsuarioNombre),
                    new Claim("FullName", $"{user.Nombres} {user.Apellidos}")
                }),
                Expires = DateTime.UtcNow.AddDays(expiresInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
