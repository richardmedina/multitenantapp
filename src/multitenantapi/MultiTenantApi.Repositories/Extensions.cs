using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Repositories.Repos;
using AutoMapper;
using MultiTenantApi.Repositories.AutoMapper;

namespace MultiTenantApi.Repositories
{
    public static class Extensions
    {

        public static void AddRepositories(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<MultiTenantApiDbContext>(options => options.UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
