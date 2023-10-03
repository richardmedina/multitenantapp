using AutoMapper;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Contract.Domain.Types;
using MultiTenantApi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Repositories.Repos
{
    public class ItemRepository : RepositoryBase<ItemEntity, ItemDomain>, IItemRepository
    {
        public ItemRepository(MultiTenantApiDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
