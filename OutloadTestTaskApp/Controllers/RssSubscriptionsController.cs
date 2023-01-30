using Microsoft.AspNetCore.Mvc;
using OutloadTestTaskApp.CustomException;
using OutloadTestTaskApp.Services;

namespace OutloadTestTaskApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RssSubscriptionsController : ControllerBase
    {
        private readonly IRssSubscriptionService _rssSubscriptionService;

        public RssSubscriptionsController(IRssSubscriptionService rssSubscriptionService)
        {
            _rssSubscriptionService = rssSubscriptionService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] string feedUrl)
        {
            var rssSubscription = await _rssSubscriptionService.AddAsync(feedUrl);
            return CreatedAtAction(nameof(Get), new { id = rssSubscription.Id }, rssSubscription);
        }

        [HttpPut, Route("SetAsRead/{id:guid}")]
        public async Task<IActionResult> SetAsRead(Guid id)
        {
            try
            {
                await _rssSubscriptionService.SetAsReadAsync(id);
            }
            catch (EntityNotFoundException)
            {
                return BadRequest($"RSS Subscription with the id {id} is not found");
            }
            return NoContent();
        }

        [HttpGet, Route("Get/{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var rssSubscription = await _rssSubscriptionService.GetByIdAsync(id);

            if (rssSubscription is null)
            {
                NotFound();
            }
            return Ok(rssSubscription);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rssSubscriptions = await _rssSubscriptionService.GetAllAsync();
            return Ok(rssSubscriptions);
        }

        [HttpGet("GetAllUnread")]
        public async Task<IActionResult> GetAllUnread([FromQuery] DateTimeOffset date)
        {
            var rssSubscriptions = await _rssSubscriptionService.GetAllUnreadNewsAsync(date);
            return Ok(rssSubscriptions);
        }
    }
}
