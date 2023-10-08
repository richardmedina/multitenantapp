using AutoMapper;
using MultiTenantApi.Contract.Services.Item;
using MultiTenantApi.Contract.Services.User;
using MultiTenantApi.Models.Item;
using MultiTenantApi.Models.User;

namespace MultiTenantApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
            CreateMap<CreateUserModel, UserDto>()
                .ReverseMap();
            CreateMap<ItemModel, ItemDto>()
                .ReverseMap();
        }
    }
}
