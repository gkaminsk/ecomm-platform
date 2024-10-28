using CartService.Api.Contracts.Responses;
using CartService.Api.DataAccessLayer.Models;
using CartService.Api.DataAccessLayer.Repositories.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace CartService.Api.DataAccessLayer.Repositories
{
    public class CartRepository : ICartRepository
    {
        //DataSource mocked by InMemory cache
        private readonly IMemoryCache _memoryCache;

        public CartRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<Cart?> ViewCart(long cartId, CancellationToken token)
        {
            _memoryCache.TryGetValue<Cart>(CreateKey(cartId), out var cart);

            return await Task.FromResult(cart);
        }

        public async Task<CartItem?> AddItem(long cartId, ProductResponse product, int quantity, CancellationToken token)
        {
            var key = CreateKey(cartId);

            if (_memoryCache.TryGetValue<Cart>(key, out var cart))
            {
                var cartItem = cart?.CartItems?.SingleOrDefault(x => x.ProductId == product.ProductId);

                if (cartItem is null)
                {
                    cartItem = new CartItem 
                    {
                        CartId = cartId,
                        ProductId = product.ProductId,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = quantity,
                        ProductUrl = product.Url,
                        ProductImage = product.Image
                    };

                    cart?.CartItems?.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity += quantity;
                }

                return await Task.FromResult(cartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cartId,
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    ProductUrl = product.Url,
                    ProductImage = product.Image
                };

                var entry = new Cart
                {
                    CartId = cartId,
                    CartItems = new List<CartItem> { cartItem }
                };

                _memoryCache.Set(key, entry);
                
                return await Task.FromResult(cartItem);
            };
        }

        public async Task<CartItem?> GetItem(long cartId, long productId, CancellationToken token)
        {
            var key = CreateKey(cartId);

            if (_memoryCache.TryGetValue<Cart>(key, out var cart))
            {
                return cart?.CartItems?.SingleOrDefault(x => x.ProductId == productId);
            }

            await Task.CompletedTask;
            return null;
        }

        public async Task<CartItem?> UpdateItem(long cartId, long productId, int quantity, CancellationToken token)
        {
            var key = CreateKey(cartId);
            
            if (_memoryCache.TryGetValue<Cart>(CreateKey(cartId), out var cart))
            {
                var cartItem = cart?.CartItems?
                    .Where(x => x.ProductId == productId)
                    .SingleOrDefault();

                if (cartItem is not null)
                {
                    cartItem.Quantity = quantity;

                    _memoryCache.Set(key, cart);
                    
                    return cartItem;
                }
            }

            await Task.CompletedTask;
            return null;
        }

        public async Task DeleteItem(long cartId, long productId, CancellationToken token)
        {
            var key = CreateKey(cartId);

            if (_memoryCache.TryGetValue<Cart>(key, out var cart))
            {
                var product = cart?.CartItems?.SingleOrDefault(x => x.ProductId == productId);

                if (product is not null)
                {
                    cart?.CartItems?.Remove(product);

                    _memoryCache.Set(key, cart);
                }
            }

            await Task.CompletedTask;
        }

        public async Task ClearCart(long cartId, CancellationToken token)
        {
            _memoryCache.Remove(CreateKey(cartId));

            await Task.CompletedTask;
        }

        private static string CreateKey(long cartId)
        {
            return $"cart_{cartId}";
        }
    }
}
