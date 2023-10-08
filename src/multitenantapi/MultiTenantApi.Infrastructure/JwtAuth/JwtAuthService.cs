using Microsoft.IdentityModel.Tokens;
using MultiTenantApi.Infrastructure.JwtAuth.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Infrastructure.JwtAuth
{
    public class JwtAuthService : IJwtAuthService
    {
        public async Task<JwtAuthenticatedUser> AuthenticateAsync(JwtAuthenticateData authenticateData)
        {
            await Task.Yield();

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, JwtConfiguration.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", authenticateData.UserId.ToString()),
                    new Claim("DisplayName", $"{authenticateData.FirstName} {authenticateData.LastName}"),
                    new Claim("UserName", authenticateData.UserName),
                    new Claim("Email", authenticateData.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

            var signin = new SigningCredentials(JwtConfiguration.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                JwtConfiguration.Issuer,
                JwtConfiguration.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(3),
                signingCredentials: signin
                );

            return new JwtAuthenticatedUser
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Claims = claims,
            };
        }
    }
}
