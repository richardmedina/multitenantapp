using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantApi.Infrastructure.Data;

namespace MultiTenantApi.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<MultiTenantApiDbContext>(options => options.UseSqlServer(connectionString));
            /*services.AddIdentity<UserEntity, IdentityRole>(
                options =>
                {
                    options.Password.RequiredLength = 5;
                })
                .AddEntityFrameworkStores<MultiTenantApiDbContext>()
                .AddDefaultTokenProviders();
            */
        }
    }
}
