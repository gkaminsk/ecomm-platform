using CartService.Api.Contracts.Requests;
using CartService.Api.Contracts.Responses;
using CartService.Api.DataAccessLayer.Repositories.Abstractions;
using CartService.Api.Infrastructure.Extensions;
using CartService.Api.Infrastructure.HttpCommunication.Abstractions;
using CartService.Api.Infrastructure.Services.Abstractions;
using CSharpFunctionalExtensions;

namespace CartService.Api.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductServiceHttpClient _productServiceHttpClient;
        private readonly IInventoryServiceHttpClient _inventoryServiceHttpClient;

        public CartService(
            ICartRepository cartRepository,
            IProductServiceHttpClient productServiceHttpClient,
            IInventoryServiceHttpClient inventoryServiceHttpClient)
        {
            _cartRepository = cartRepository;
            _productServiceHttpClient = productServiceHttpClient;
            _inventoryServiceHttpClient = inventoryServiceHttpClient;
        }

        public async Task<Result<CartResponse>> ViewCart(CancellationToken token)
        {
            var cartId = GetCartId();

            var cart = await _cartRepository.ViewCart(cartId, token);

            if (cart is null || cart?.CartItems?.Count == 0)
            {
                return Result.Success(new CartResponse());
            }

            var cartResponse = cart.ToCartResponse();

            return Result.Success(cartResponse);
        }

        public async Task<Result<CartItemResponse>> AddItem(CartItemRequest request, CancellationToken token)
        {
            var cartId = GetCartId();
            var product = await _productServiceHttpClient.GetProductAsync(request.ProductId, token);

            if (product is null)
            {
                return Result.Failure<CartItemResponse>($"Cart Error. Product {request.ProductId} not found");
            }

            var exisitingItem = await _cartRepository.GetItem(cartId, product.ProductId, token);
            var newQuantity = (exisitingItem?.Quantity ?? 0) + request.Quantity;

            var inventoryCheck = await CheckInventory(cartId, product, newQuantity, token);

            if (inventoryCheck.IsFailure)
            {
                return Result.Failure<CartItemResponse>(inventoryCheck.Error);
            }

            var result = await _cartRepository.AddItem(cartId, product, request.Quantity, token);

            return Result.Success(result.ToCartItemResponse());
        }

        public async Task<Result<CartItemResponse>> UpdateItem(CartItemRequest request, CancellationToken token)
        {
            var cartId = GetCartId();
            var product = await _productServiceHttpClient.GetProductAsync(request.ProductId, token);

            if (product is null)
            {
                return Result.Failure<CartItemResponse>($"Cart Error. Product {request.ProductId} not found");
            }

            var inventoryCheck = await CheckInventory(cartId, product, request.Quantity, token);

            if (inventoryCheck.IsFailure)
            {
                return Result.Failure<CartItemResponse>(inventoryCheck.Error);
            }

            var result = await _cartRepository.UpdateItem(cartId, request.ProductId, request.Quantity, token);

            return Result.Success(result.ToCartItemResponse());
        }

        public async Task<Result> DeleteItem(long productId, CancellationToken token)
        {
            var cartId = GetCartId();

            await _cartRepository.DeleteItem(cartId, productId, token);

            return Result.Success();
        }

        public async Task<Result> ClearCart(CancellationToken token)
        {
            var cartId = GetCartId();

            await _cartRepository.ClearCart(cartId, token);

            return Result.Success();
        }

        private async Task<Result> CheckInventory(long cartId, ProductResponse product, int newQuantity, CancellationToken token)
        {
            var inventory = await _inventoryServiceHttpClient.GetInventoryAsync(product.ProductId, token);

            if (inventory?.TotalQuantity == 0)
            {
                return Result.Failure($"Cart Error. The product '{product.Name}' is already sold out.");
            }
            else if (newQuantity > inventory?.TotalQuantity)
            {
                return Result.Failure($"Cart Error. You can't have more then {inventory?.TotalQuantity} of the '{product.Name}' in the cart.");
            }

            return Result.Success();
        }

        // Mocked logic for getting cart by user name. Implement accordingly
        private static long GetCartId(string username = "user")
        {
            long hash = username.GetHashCode();

            return Math.Abs(hash);
        }
    }
}
