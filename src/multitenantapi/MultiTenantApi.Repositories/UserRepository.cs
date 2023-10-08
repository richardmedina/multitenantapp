using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Infrastructure.Data;
using MultiTenantApi.Infrastructure.Data.Entities;

namespace MultiTenantApi.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity, UserDomain>, IUserRepository
    {
        public UserRepository(MultiTenantApiDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserDomain?> GetFromUserNameAsync(string userName)
        {
            var userEntity = await Context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            return Mapper.Map<UserDomain>(userEntity);
        }
    }
}
