using Microsoft.EntityFrameworkCore;
using OutloadTestTaskApp.Models;

namespace OutloadTestTaskApp.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<RssSubscription> RssSubscriptions { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
    }
}
