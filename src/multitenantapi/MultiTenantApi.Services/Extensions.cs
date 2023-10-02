using Microsoft.Extensions.DependencyInjection;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Services.AutoMapper;
using MultiTenantApi.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Services
{
    public static class Extensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUserService, UserService>();
        }
    }
}
