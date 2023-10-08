using MultiTenantApi.Infrastructure.JwtAuth.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Infrastructure.JwtAuth
{
    public interface IJwtAuthService
    {
        public Task<JwtAuthenticatedUser?> AuthenticateAsync(JwtAuthenticateData userCredentials);
    }
}
