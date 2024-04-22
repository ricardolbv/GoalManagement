using GoalManagement.Application.Contracts.Common;
using GoalManagement.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GoalManagement.Infraestructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync()
        {
            OnBeforeCommit();
            await context.SaveChangesAsync();
        }

        private void OnBeforeCommit()
        {
            OnBeforeCommitEditing();
            OnBeforeCommitAdding();
        }

        private void OnBeforeCommitEditing()
        {
            foreach (var entity in context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                OnBeforeSaveUpdate(entity);
            }
        }

        private void OnBeforeSaveUpdate(EntityEntry entity)
        {
            if (entity.Entity is AuditableEntity auditableEntity)
            {
                auditableEntity.UpdatedAt = DateTime.UtcNow;
            }
        }

        private void OnBeforeCommitAdding()
        {
            foreach (var entity in context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                OnBeforeSaveAdding(entity);
            }
        }

        private void OnBeforeSaveAdding(EntityEntry entity)
        {
            if (entity.Entity is AuditableEntity auditableEntity)
            {
                auditableEntity.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}
