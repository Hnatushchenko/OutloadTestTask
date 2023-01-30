using OutloadTestTaskApp.Models;

namespace OutloadTestTaskApp.Services
{
    public interface IRssSubscriptionService
    {
        Task<RssSubscription> AddAsync(string feedUrl);
        Task<RssSubscription?> GetByIdAsync(Guid id);
        Task<IEnumerable<RssSubscription>> GetAllAsync();
        Task<IEnumerable<RssSubscription>> GetAllUnreadNewsAsync(DateTimeOffset date);
        Task SetAsReadAsync(Guid id);
    }
}