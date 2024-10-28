using CartService.Api.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartService.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(
            ICheckoutService checkoutService,
            ILogger<CartController> logger)
        {
            _logger = logger;
            _checkoutService = checkoutService;
        }

        /// <summary>
        /// Starts cart checkout process and eventually publishes order
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Starts cart checkout process and eventually publishes order")]
        [SwaggerResponse(StatusCodes.Status200OK, "Order was published")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CheckoutCart(CancellationToken token = default)
        {
            //TODO:
            var result = await _checkoutService.CheckoutCart(token);
            
            return result.IsSuccess 
                    ? this.Ok(result.GetValueOrDefault())
                    : this.BadRequest(result.Error);
        }
    }
}
