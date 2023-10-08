using AutoMapper;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Contract.Services.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> CreateAsync(ItemDto itemDto)
        {
            var item = _mapper.Map<ItemDomain>(itemDto);

            var createdItem = await _itemRepository.CreateAsync(item);

            return _mapper.Map<ItemDto>(createdItem);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                await _itemRepository.DeleteAsync(id);
            }catch
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ItemDto>>(await _itemRepository.GetAllAsync());
        }

        public async Task<ItemDto?> GetAsync(Guid id)
        {
            return _mapper.Map<ItemDto>(await _itemRepository.GetAsync(id));
        }

        public async Task<bool> UpdateAsync(ItemDto itemDto)
        {
            try
            {
                await _itemRepository.UpdateAsync(_mapper.Map<ItemDomain>(itemDto));
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
