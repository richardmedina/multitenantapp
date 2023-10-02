using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly MultiTenantApiDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(MultiTenantApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDomain> CreateAsync(UserDomain user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            entity.Id = Guid.NewGuid();

            var createdUserEntity = await _context.Users.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDomain>(createdUserEntity.Entity);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = _context.Users.Single(user => user.Id == userId);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserDomain?> GetAsync(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.Id == userId);
            return _mapper.Map<UserDomain?>(user);
        }

        public async Task<IEnumerable<UserDomain>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDomain>>(users);
        }

        public async Task UpdateAsync(UserDomain user)
        {
            var userEntity = await _context.Users.SingleAsync(u => u.Id == user.Id);

            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Password = user.Password;


            await _context.SaveChangesAsync();
        }
    }
}
