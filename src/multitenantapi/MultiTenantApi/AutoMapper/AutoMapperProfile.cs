using AutoMapper;
using MultiTenantApi.Contract.Services.Authentication;
using MultiTenantApi.Contract.Services.Item;
using MultiTenantApi.Contract.Services.User;
using MultiTenantApi.Models.Auth;
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
            CreateMap<UserCredentialModel, UserCredentialDto>()
                .ReverseMap();
        }
    }
}
