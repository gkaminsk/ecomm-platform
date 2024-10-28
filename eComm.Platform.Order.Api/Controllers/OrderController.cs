using Microsoft.AspNetCore.Mvc;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(long orderId, CancellationToken token = default)
        {
            //TODO:

            await Task.CompletedTask;
            return this.Ok();
        }

        [HttpGet("all/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(long userId, CancellationToken token = default)
        {
            //TODO:

            await Task.CompletedTask;
            return this.Ok();
        }
    }
}
