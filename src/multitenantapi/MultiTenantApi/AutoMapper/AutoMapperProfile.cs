using AutoMapper;
using MultiTenantApi.Contract.Services.User;
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
        }
    }
}
