using ProductService.Api.DataAccessLayer.Models;

namespace ProductService.Api.DataAccessLayer.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<Product?> GetProductById(
            long Id,
            CancellationToken token = default);

        Task<IEnumerable<Product>?> GetProductsByIds(
            IEnumerable<long> productIds,
            CancellationToken token = default);

        Task<(IEnumerable<Product>? products, int totalCount)> GetProducts(
            int pageSize,
            int offset,
            CancellationToken token = default);

        Task<(IEnumerable<Product>? products, int totalCount)> SearchProduct(
            string? name,
            int? categoryId,
            int pageSize,
            int offset,
            CancellationToken token = default);
    }
}