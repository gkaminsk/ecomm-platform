using ProductService.Api.Contracts.Responses;
using ProductService.Api.DataAccessLayer.Models;

namespace ProductService.Api.Infrastructure.Extensions
{
    public static class ProductExtensions
    {
        public static ProductResponse ToProductResponse(this Product input)
        {
            return new ProductResponse 
            { 
                ProductId = input.ProductId,
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                CategoryId = input.CategoryId,
                Sku = input.Sku,
                Url = input.Url,
                Image = input.Image,
            };
        }
    }
}
