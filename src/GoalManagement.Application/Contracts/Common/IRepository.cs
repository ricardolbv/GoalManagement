namespace GoalManagement.Application.Contracts.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Adding
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        //Removing
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        //Getting
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync(); 
    }
}
