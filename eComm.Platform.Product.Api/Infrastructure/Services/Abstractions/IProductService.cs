using CSharpFunctionalExtensions;
using ProductService.Api.Contracts.Responses;

namespace ProductService.Api.Infrastructure.Services.Abstractions
{
    public interface IProductService
    {
        Task<Result<ProductResponse?>> GetProductById(
            long Id,
            CancellationToken token = default);

        Task<Result<ProductsResponse>> GetProductsByIds(
            IEnumerable<long> productIds,
            CancellationToken token = default);

        Task<Result<ProductsResponse>> GetProducts(
            int pageSize,
            int page,
            CancellationToken token = default);

        Task<Result<ProductsResponse>> SearchProduct(
            string? name,
            int? categoryId,
            int pageSize,
            int page,
            CancellationToken token = default);
    }
}