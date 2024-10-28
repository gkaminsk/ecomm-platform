using CartService.Api.Contracts.Responses;
using CartService.Api.DataAccessLayer.Models;

namespace CartService.Api.DataAccessLayer.Repositories.Abstractions
{
    public interface ICartRepository
    {
        Task<Cart?> ViewCart(long cartId, CancellationToken token);

        Task<CartItem?> AddItem(long cartId, ProductResponse product, int quantity, CancellationToken token);

        Task<CartItem?> GetItem(long cartId, long productId, CancellationToken token);

        Task<CartItem?> UpdateItem(long cartId, long productId, int quantity, CancellationToken token);

        Task DeleteItem(long cartId, long productId, CancellationToken token);

        Task ClearCart(long cartId, CancellationToken token);
    }
}