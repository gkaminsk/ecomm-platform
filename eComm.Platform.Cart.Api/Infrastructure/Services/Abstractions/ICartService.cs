using CartService.Api.Contracts.Requests;
using CartService.Api.Contracts.Responses;
using CSharpFunctionalExtensions;

namespace CartService.Api.Infrastructure.Services.Abstractions
{
    public interface ICartService
    {
        Task<Result<CartResponse>> ViewCart(CancellationToken token);

        Task<Result<CartItemResponse>> AddItem(CartItemRequest cartItem, CancellationToken token);

        Task<Result<CartItemResponse>> UpdateItem(CartItemRequest cartItem, CancellationToken token);

        Task<Result> DeleteItem(long productId, CancellationToken token);

        Task<Result> ClearCart(CancellationToken token);
    }
}
