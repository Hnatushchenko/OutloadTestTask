using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OutloadTestTaskApp.Models;

namespace OutloadTestTaskApp.Repository
{
    public interface IApplicationDbContext
    {
        DbSet<RssSubscription> RssSubscriptions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
