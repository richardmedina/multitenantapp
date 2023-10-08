using AutoMapper;
using Microsoft.Extensions.Logging;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Common.Utils;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Contract.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiTenantApi.Services.User
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            _logger.LogInformation(LogFormater.Format("Creating user", userDto));

            var userDomain = _mapper.Map<UserDomain>(userDto);
            var createdUserDomain = await _userRepository.CreateAsync(userDomain);

            _logger.LogInformation(LogFormater.Format("Created User"));

            return _mapper.Map<UserDto>(createdUserDomain);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                _logger.LogInformation(LogFormater.Format("Deleting user", id));
                await _userRepository.DeleteAsync(id);
            }catch(Exception ex)
            {
                _logger.LogError(ex, LogFormater.Format("Error deleting user", id));
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            _logger.LogInformation(LogFormater.Format("Getting all users"));
            var domainUsers = await _userRepository.GetAllAsync();
            _logger.LogInformation(LogFormater.Format("Got all users"));

            return _mapper.Map<IEnumerable<UserDto>>(domainUsers);
        }

        public async Task<UserDto?> GetAsync(Guid id)
        {
            UserDto? userDto = null;

            _logger.LogInformation(LogFormater.Format("Retriving user", id));
            try
            {
                var userDomain = await _userRepository.GetAsync(id);
                userDto = _mapper.Map<UserDto>(userDomain);
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogError(ex, LogFormater.Format("Error retreiving user id", id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, LogFormater.Format("Error retreiving user id", id));
                throw;
            }

            return userDto;
        }

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
            _logger.LogInformation(LogFormater.Format("Updating user", userDto));
            try
            {
                await _userRepository.UpdateAsync(_mapper.Map<UserDomain>(userDto));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, LogFormater.Format("Error updating user: ", userDto));
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, LogFormater.Format("Error updating user: ", userDto));
                throw;
            }

            return true;
        }

        public async Task<UserDto?> GetFromUserNameAsync(string userName)
        {
            var userDomain = await _userRepository.GetFromUserNameAsync(userName);

            return _mapper.Map<UserDto>(userDomain);
        }
    }
}
