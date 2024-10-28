using CartService.Api.Contracts.Requests;
using CartService.Api.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;

        public CartController(
            ICartService cartService,
            ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }


        /// <summary>
        /// Returns the contents of the shopping cart
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Returns the contents of the shopping cart")]
        [SwaggerResponse(StatusCodes.Status200OK, "Shopping cart content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token = default)
        {
            var result = await _cartService.ViewCart(token);

            return result.IsSuccess
                ? this.Ok(result.GetValueOrDefault())
                : this.BadRequest(result.Error);
        }

        /// <summary>
        /// Adds a product to the cart
        /// </summary>
        /// <param name="cartItem"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Adds a product to the cart")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product added to cart")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CartItemRequest cartItem, 
            CancellationToken token = default)
        {
            var result = await _cartService.AddItem(cartItem, token);

            return result.IsSuccess
                    ? this.Ok(result.GetValueOrDefault())
                    : this.UnprocessableEntity(result.Error);
        }

        /// <summary>
        /// Updates product quentity in the cart
        /// </summary>
        /// <param name="cartItem"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Updates product quentity in the cart")]
        [SwaggerResponse(StatusCodes.Status200OK, "Quentity updated")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpPatch("update")]
        public async Task<IActionResult> Update(
            [FromBody] CartItemRequest cartItem, 
            CancellationToken token = default)
        {
            var result = await _cartService.UpdateItem(cartItem, token);

            return result.IsSuccess
                    ? this.Ok(result.GetValueOrDefault())
                    : this.UnprocessableEntity(result.Error);
        }

        /// <summary>
        /// Removes product from the cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Removes product from the cart")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product removed")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> Delete(
            [FromRoute] long productId, 
            CancellationToken token = default)
        {
            var result = await _cartService.DeleteItem(productId, token);

            return result.IsSuccess
                ? this.Ok()
                : this.UnprocessableEntity(result.Error);
        }

        /// <summary>
        /// Clears cart content
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Clears cart content")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cart was cleard")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpDelete("clear")]
        public async Task<IActionResult> Clear(CancellationToken token = default)
        {
            var result = await _cartService.ClearCart(token);

            return result.IsSuccess
                ? this.Ok()
                : this.BadRequest(result.Error);
        }
    }
}
