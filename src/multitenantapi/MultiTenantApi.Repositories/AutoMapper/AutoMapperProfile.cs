using AutoMapper;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Infrastructure.Data.Entities;

namespace MultiTenantApi.Repositories.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDomain, UserEntity>()
                .ReverseMap();
            CreateMap<ItemDomain, ItemEntity>()
                .ReverseMap();
        }
    }
}
