using MultiTenantApi.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Repositories
{
    public interface IItemRepository
    {
        Task<ItemDomain?> GetAsync(Guid itemId);
        Task<IEnumerable<ItemDomain>> GetAllAsync();
        Task<ItemDomain> CreateAsync(ItemDomain user);
        Task UpdateAsync(ItemDomain user);
        Task DeleteAsync(Guid user);
    }
}
