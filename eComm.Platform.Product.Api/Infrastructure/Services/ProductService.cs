using CSharpFunctionalExtensions;
using ProductService.Api.Contracts.Responses;
using ProductService.Api.DataAccessLayer.Repositories.Abstractions;
using ProductService.Api.Infrastructure.Extensions;
using ProductService.Api.Infrastructure.Services.Abstractions;

namespace ProductService.Api.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IProductRepository productRepository,
            ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Result<ProductResponse?>> GetProductById(
            long productId,
            CancellationToken token = default)
        {
            var product = await _productRepository.GetProductById(productId, token);

            return Result.Success(product?.ToProductResponse());
        }

        public async Task<Result<ProductsResponse>> GetProductsByIds(
            IEnumerable<long> productIds,
            CancellationToken token = default)
        {
            var products = await _productRepository.GetProductsByIds(productIds, token);

            var results = new ProductsResponse
            {
                Products = products?.Select(x => x.ToProductResponse()),
                TotalCount = products?.Count() ?? 0
            };

            return Result.Success(results);
        }

        public async Task<Result<ProductsResponse>> GetProducts(
            int pageSize,
            int page,
            CancellationToken token = default)
        {
            var offset = ComputeOffset(pageSize, page);

            var (products, totalCount) = await _productRepository.GetProducts(pageSize, offset, token);

            var result = new ProductsResponse
            { 
                Products = products?.Select(x => x.ToProductResponse()),
                TotalCount = totalCount
            };

            return Result.Success(result);
        }

        public async Task<Result<ProductsResponse>> SearchProduct(
            string? name,
            int? categoryId,
            int pageSize,
            int page,
            CancellationToken token = default)
        {
            var offset = ComputeOffset(pageSize, page);

            var (products, totalCount) = await _productRepository.SearchProduct(name, categoryId, pageSize, offset, token);

            var result = new ProductsResponse
            {
                Products = products?.Select(x => x.ToProductResponse()),
                TotalCount = totalCount
            };

            return Result.Success(result);
        }

        private static int ComputeOffset(int pageSize, int page)
        {
            return (page - 1) * pageSize;
        }
    }
}
