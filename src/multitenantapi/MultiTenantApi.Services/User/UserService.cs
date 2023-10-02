using AutoMapper;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Contract.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Services.User
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var userDomain = _mapper.Map<UserDomain>(userDto);
            var createdUserDomain = await _userRepository.CreateAsync(userDomain);

            return _mapper.Map<UserDto>(createdUserDomain);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
            }catch
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDto?> GetAsync(Guid id)
        {
            var userDomain = await _userRepository.GetAsync(id);

            return _mapper.Map<UserDto>(userDomain);
        }

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
            try
            {
                await _userRepository.UpdateAsync(_mapper.Map<UserDomain>(userDto));
            }
            catch
            {
                return false;
            }

            return true;
        }


    }
}
