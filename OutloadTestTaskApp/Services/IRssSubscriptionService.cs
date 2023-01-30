using OutloadTestTaskApp.Models;

namespace OutloadTestTaskApp.Services
{
    public interface IRssSubscriptionService
    {
        Task AddAsync(string feedUrl);
        Task<IEnumerable<RssSubscription>> GetAllAsync();
        Task<IEnumerable<RssSubscription>> GetAllUnreadNewsAsync(DateTimeOffset date);
        Task SetAsReadAsync(Guid id);
    }
}