using CartService.Api.Contracts.Requests;
using CartService.Api.Contracts.Responses;

namespace CartService.Api.Infrastructure.HttpCommunication.Abstractions
{
    public interface IProductServiceHttpClient
    {
        Task<IEnumerable<ProductResponse>> GetProductsAsync(
            ProductsRequest request,
            CancellationToken token = default);

        Task<ProductResponse?> GetProductAsync(
            long productId,
            CancellationToken token = default);
    }
}
