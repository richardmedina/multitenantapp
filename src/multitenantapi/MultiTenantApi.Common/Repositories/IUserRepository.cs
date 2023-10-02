using MultiTenantApi.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Repositories
{
    public interface IUserRepository
    {
        Task<UserDomain?> GetAsync(Guid userId);
        Task<IEnumerable<UserDomain>> GetAllAsync();
        Task<UserDomain> CreateAsync(UserDomain user);
        Task UpdateAsync(UserDomain user);
        Task DeleteAsync(Guid user);
    }
}
