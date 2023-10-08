using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Contract.Domain.Types;
using MultiTenantApi.Infrastructure.Data;
using MultiTenantApi.Infrastructure.Data.Types;

namespace MultiTenantApi.Repositories
{
    public abstract class RepositoryBase<TEntityType, TDomainType>
        where TEntityType : class, IEntityType
        where TDomainType : class, IDomainType
    {
        protected MultiTenantApiDbContext Context { get; }
        protected IMapper Mapper { get; }

        private readonly DbSet<TEntityType> dbSet;

        public RepositoryBase(MultiTenantApiDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;

            dbSet = Context.Set<TEntityType>();
        }

        public async Task<TDomainType> CreateAsync(TDomainType domainType)
        {
            var entity = Mapper.Map<TEntityType>(domainType);
            entity.Id = Guid.NewGuid();

            var createdEntity = await dbSet.AddAsync(entity);

            await Context.SaveChangesAsync();

            return Mapper.Map<TDomainType>(createdEntity.Entity);
        }
        public async Task UpdateAsync(TDomainType domainType)
        {
            var entity = await dbSet.SingleAsync(entity => entity.Id == domainType.Id);

            var updatedEntity = Mapper.Map<TEntityType>(domainType);
            updatedEntity.Id = entity.Id;
            dbSet.Attach(updatedEntity).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }
        public async Task<TDomainType?> GetAsync(Guid id)
        {
            var entity = await dbSet.SingleAsync(entity => entity.Id == id);

            return Mapper.Map<TDomainType>(entity);
        }

        public async Task<IEnumerable<TDomainType>> GetAllAsync()
        {
            var entities = await dbSet.ToListAsync();

            return Mapper.Map<IEnumerable<TDomainType>>(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await dbSet.SingleAsync(entity => entity.Id == id);

            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
