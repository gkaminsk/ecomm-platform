using CartService.Api.DataAccessLayer.Repositories.Abstractions;
using CartService.Api.Infrastructure.Services.Abstractions;
using CSharpFunctionalExtensions;

namespace CartService.Api.Infrastructure.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICartRepository _cartRepository;

        public CheckoutService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<string>> CheckoutCart(CancellationToken token)
        {
            //TODO:

            //Mocked:
            var cartId = GetCartId();
            var cart = await _cartRepository.ViewCart(cartId, token);

            if (cart is null || cart?.CartItems?.Count == 0)
            {
                return Result.Failure<string>("Cart is empty");
            }

            return await PublishOrder(cartId, token);
        }

        private async Task<Result<string>> PublishOrder(long cartId, CancellationToken token)
        {
            //TODO:

            //Mocked:
            var orderId = new Random(1000).Next();
            await _cartRepository.ClearCart(cartId, token);

            return Result.Success($"Order No {orderId} has been placed.");
        }

        // Mocked logic for getting cart by user name. Implement accordingly
        private static long GetCartId(string username = "user")
        {
            long hash = username.GetHashCode();

            return Math.Abs(hash);
        }
    }
}
