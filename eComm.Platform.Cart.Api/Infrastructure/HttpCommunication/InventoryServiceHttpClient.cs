using CartService.Api.Contracts.Responses;
using CartService.Api.DataAccessLayer.Mock;
using CartService.Api.Infrastructure.HttpCommunication.Abstractions;

namespace CartService.Api.Infrastructure.HttpCommunication
{
    public class InventoryServiceHttpClient : IInventoryServiceHttpClient
    {
        private readonly HttpClient _httpClient;

        public InventoryServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InventoryResponse?> GetInventoryAsync(
            long productId, 
            CancellationToken token = default)
        {
            //Mocked call to Inventory service
            var response = MockedData.AllInventory
                .Where(x => x.ProductId == productId)
                .SingleOrDefault();

            return await Task.FromResult(response);
        }
    }
}
