using Microsoft.EntityFrameworkCore;
using OutloadTestTaskApp.Models;

namespace OutloadTestTaskApp.Repository
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<RssSubscription> RssSubscriptions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
