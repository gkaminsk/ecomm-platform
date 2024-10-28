using CartService.Api.Contracts.Responses;
using CartService.Api.DataAccessLayer.Models;

namespace CartService.Api.Infrastructure.Extensions
{
    public static class CartExtensions
    {
        public static CartResponse ToCartResponse(this Cart input)
        {
            return new CartResponse
            {
                CartId = input?.CartId,
                CartItems = input?.CartItems?.Select(x => x.ToCartItemResponse()),
                TotalPrice = input?.CartItems?.Sum(x => x.Price * x.Quantity) ?? 0
            };
        }

        public static CartItemResponse ToCartItemResponse(this CartItem input)
        { 
            return new CartItemResponse
            {
                CartId = input.CartId,
                ProductId = input.ProductId,
                ProductName = input.ProductName,
                ProductPrice = input.Price,
                Quantity = input.Quantity,
                ProductUrl = input.ProductUrl,
                ProductImage = input.ProductImage
            };
        }
    }
}
