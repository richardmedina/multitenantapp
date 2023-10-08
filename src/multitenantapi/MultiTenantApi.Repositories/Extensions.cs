using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantApi.Common.Repositories;
using AutoMapper;
using MultiTenantApi.Repositories.AutoMapper;
using MultiTenantApi.Infrastructure.Data;

namespace MultiTenantApi.Repositories
{
    public static class Extensions
    {

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
