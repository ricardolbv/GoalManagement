namespace GoalManagement.Application.Contracts.Common
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
