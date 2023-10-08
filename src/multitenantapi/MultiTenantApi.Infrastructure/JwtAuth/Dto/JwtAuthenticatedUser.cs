using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Infrastructure.JwtAuth.Dto
{
    public class JwtAuthenticatedUser
    {
        public string Token { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
