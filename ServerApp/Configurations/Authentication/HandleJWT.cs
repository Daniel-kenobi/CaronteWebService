using Barsa.Models.User;
using Barsa.Models.JWTAppSettingsModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tartaro.Data.Entities;

namespace Tartaro.Configurations.Authentication
{
    public abstract class HandleJWT
    {
        private readonly IOptions<JWTAppSettings> _jwtModel;
        public HandleJWT(IOptions<JWTAppSettings> jwtModel)
        {
            _jwtModel = jwtModel;
        }

        public string GenerateToken(UserLoginModel user)
        {
            var issuer = _jwtModel.Value.Issuer;
            var audience = _jwtModel.Value.Audience;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.Value.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = GenerateUserClaims(user);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials, claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

        private List<Claim> GenerateUserClaims(UserLoginModel user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Version, user.OSVersion)
            };
        }
    }
}
