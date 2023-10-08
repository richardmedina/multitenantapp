using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Infrastructure.JwtAuth.Dto
{
    public class JwtConfiguration
    {
        public static string Key = "TestSymmetricSecurityKey";

        public static SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        public static string Issuer = "JWTAuthenticationServer";
        public static string Audience = "JWTServicePostManClient";
        public static string Subject = "JWTServiceAccessToken";
    }
}
