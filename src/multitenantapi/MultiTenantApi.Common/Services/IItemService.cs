using MultiTenantApi.Contract.Services.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Services
{
    public interface IItemService
    {
        Task<ItemDto> CreateAsync(ItemDto itemDto);
        Task<ItemDto?> GetAsync(Guid id);
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<bool> UpdateAsync(ItemDto itemDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
