using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OutloadTestTaskApp.Models;

namespace OutloadTestTaskApp.Repository
{
    public interface IApplicationDbContext
    {
        DbSet<RssSubscription> RssSubscriptions { get; set; }
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
