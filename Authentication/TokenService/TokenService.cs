using CaronteWebService.Requests.Login;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace CaronteWebService.Authentication.TokenService
{
    public static class TokenService
    {
        public static string GenerateToken(UserLoginRequest User)
        {
            var secretKey = Environment.GetEnvironmentVariable("Secret");

            if (secretKey?.Length <= 0)
                throw new Exception("Secret key não configurada");

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, User.UserLoginCredentials.UserName), 
                    new Claim(ClaimTypes.System, User.UserLoginCredentials.WindowsVersion)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
