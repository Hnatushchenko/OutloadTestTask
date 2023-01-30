namespace OutloadTestTaskApp.Models
{
    public class RssSubscription
    {
        public required Guid Id { get; set; }
        public required string FeedUrl { get; set; }
        public required bool IsRead { get; set; }
        public required DateTimeOffset CreationDate { get; set; }
    }
}
