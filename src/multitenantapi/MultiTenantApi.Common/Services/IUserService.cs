using MultiTenantApi.Contract.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto createUserDto);
        Task<UserDto?> GetAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<bool> UpdateAsync(UserDto userDto);
        Task<bool> DeleteAsync(Guid id);
        Task<UserDto?> GetFromUserNameAsync(string userName);
    }
}
