using Microsoft.EntityFrameworkCore;
using OutloadTestTaskApp.CustomException;
using OutloadTestTaskApp.Models;
using OutloadTestTaskApp.Repository;

namespace OutloadTestTaskApp.Services
{
    public class RssSubscriptionService : IRssSubscriptionService
    {
        private readonly IApplicationContext _context;

        public RssSubscriptionService(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RssSubscription>> GetAllAsync()
        {
            return await _context.RssSubscriptions.ToListAsync();
        }

        public async Task<RssSubscription?> GetByIdAsync(Guid id)
        {
            return await _context.RssSubscriptions.
                Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RssSubscription>> GetAllUnreadNewsAsync(DateTimeOffset date)
        {
            var subscriptions = _context.RssSubscriptions
                .Where(x => x.IsRead == false)
                .Where(x => x.CreationDate >= date);
            return await subscriptions.ToListAsync();
        }

        public async Task<RssSubscription> AddAsync(string feedUrl)
        {
            var rssSubscription = new RssSubscription
            {
                Id = Guid.NewGuid(),
                FeedUrl = feedUrl,
                CreationDate = DateTimeOffset.Now,
                IsRead = false,
            };
            _context.RssSubscriptions.Add(rssSubscription);
            await _context.SaveChangesAsync();
            return rssSubscription;
        }

        public async Task SetAsReadAsync(Guid id)
        {
            var subscription = await _context.RssSubscriptions
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subscription is null) throw new EntityNotFoundException();

            subscription.IsRead = true;
            _context.Update(subscription);
            await _context.SaveChangesAsync();
        }
    }
}
