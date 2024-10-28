using ProductService.Api.DataAccessLayer.Mock;
using ProductService.Api.DataAccessLayer.Models;
using ProductService.Api.DataAccessLayer.Repositories.Abstractions;

namespace ProductService.Api.DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product?> GetProductById(
            long Id, 
            CancellationToken token = default)
        {
            var result = MockedData.AllProducts
                .Where(x => x.ProductId == Id)
                .SingleOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Product>?> GetProductsByIds(
            IEnumerable<long> productIds,
            CancellationToken token = default)
        {
            var result = MockedData.AllProducts
                .Where(x => productIds.ToList().Contains(x.ProductId))
                .OrderBy(x => x.CategoryId)
                .ThenBy(x => x.Name);

            return await Task.FromResult(result);
        }

        public async Task<(IEnumerable<Product>? products, int totalCount)> GetProducts(
            int pageSize, 
            int offset, 
            CancellationToken token = default)
        {
            var query = MockedData.AllProducts
                .OrderBy(x => x.CategoryId)
                .ThenBy(x => x.Name);

            var products = query
                .Skip(offset)
                .Take(pageSize);
            
            var totalCount = query.Count();

            return await Task.FromResult((products, totalCount));
        }

        public async Task<(IEnumerable<Product>? products, int totalCount)> SearchProduct(
            string? name,
            int? categoryId,
            int pageSize, 
            int offset,
            CancellationToken token = default)
        {
            var query = MockedData.AllProducts.AsEnumerable();

            if (string.IsNullOrEmpty(name) == false)
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }

            var products = query
                .OrderBy(x => x.CategoryId)
                .ThenBy(x => x.Name)
                .Skip(offset)
                .Take(pageSize);

            var totalCount = query.Count();

            return await Task.FromResult((products, totalCount));
        }
    }
}