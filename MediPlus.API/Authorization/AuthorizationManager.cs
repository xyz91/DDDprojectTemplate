using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MediPlus.API
{
    public class AuthorizationManager
    {
        public static JwtSettings JwtSettings { get; set; } = new JwtSettings();
        public static string CreateToken(params Claim[] claims)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddMinutes(JwtSettings.Expires),
                Audience = JwtSettings.Audience,
                Issuer = JwtSettings.Issuer,
                IssuedAt = DateTime.UtcNow,
                NotBefore = JwtSettings.NotBefore,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtSettings.SecretKey)),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            tokenDescriptor.Subject.AddClaims(claims);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
