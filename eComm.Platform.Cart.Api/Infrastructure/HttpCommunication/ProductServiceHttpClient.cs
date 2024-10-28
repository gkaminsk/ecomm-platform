using CartService.Api.Contracts.Requests;
using CartService.Api.Contracts.Responses;
using CartService.Api.DataAccessLayer.Mock;
using CartService.Api.Infrastructure.HttpCommunication.Abstractions;

namespace CartService.Api.Infrastructure.HttpCommunication
{
    public class ProductServiceHttpClient : IProductServiceHttpClient
    {
        private readonly HttpClient _httpClient;

        public ProductServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsAsync(
            ProductsRequest request, 
            CancellationToken token = default)
        {
            //Mocked call to Product service
            var response = MockedData.AllProducts
                .Where(x => request.Products.ToList().Contains(x.ProductId));

            return await Task.FromResult(response);
        }

        public async Task<ProductResponse?> GetProductAsync(
            long productId,
            CancellationToken token = default)
        {
            //Mocked call to Product service
            var response = MockedData.AllProducts
                .Where(x => x.ProductId == productId)
                .SingleOrDefault();

            return await Task.FromResult(response);
        }

    }
}
