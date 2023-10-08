using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MultiTenantApi.Infrastructure.Data;
using MultiTenantApi.Infrastructure.Data.Entities;
using MultiTenantApi.Infrastructure.JwtAuth;
using MultiTenantApi.Infrastructure.JwtAuth.Dto;

namespace MultiTenantApi.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<MultiTenantApiDbContext>(options => options.UseSqlServer(connectionString));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = JwtConfiguration.Audience,
                    ValidIssuer = JwtConfiguration.Issuer,
                    IssuerSigningKey = JwtConfiguration.SymmetricSecurityKey
                };
            });

            services.AddScoped<IJwtAuthService, JwtAuthService>();
        }
    }
}
