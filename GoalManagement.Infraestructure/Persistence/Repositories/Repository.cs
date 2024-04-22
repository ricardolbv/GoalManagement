using GoalManagement.Application.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace GoalManagement.Infraestructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<BaseEntity> entities)
        {
            await context.Set<BaseEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<BaseEntity>> GetAllAsync()
        {
            return await context.Set<BaseEntity>().ToListAsync();      
        }

        public async Task<BaseEntity> GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            return await context.Set<BaseEntity>().SingleAsync(x => x.);
        }

        public Task RemoveAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<BaseEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
