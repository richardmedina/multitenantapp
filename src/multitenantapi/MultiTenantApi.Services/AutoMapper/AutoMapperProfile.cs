using AutoMapper;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Contract.Services.Item;
using MultiTenantApi.Contract.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Services.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, UserDomain>()
                .ReverseMap();

            CreateMap<ItemDto, ItemDomain>()
                .ReverseMap();
        }
    }
}
