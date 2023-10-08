using AutoMapper;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Infrastructure.Data;
using MultiTenantApi.Infrastructure.Data.Entities;

namespace MultiTenantApi.Repositories
{
    public class ItemRepository : RepositoryBase<ItemEntity, ItemDomain>, IItemRepository
    {
        public ItemRepository(MultiTenantApiDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
