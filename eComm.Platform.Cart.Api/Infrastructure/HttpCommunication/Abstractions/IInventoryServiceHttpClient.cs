using CartService.Api.Contracts.Responses;

namespace CartService.Api.Infrastructure.HttpCommunication.Abstractions
{
    public interface IInventoryServiceHttpClient
    {
        Task<InventoryResponse?> GetInventoryAsync(
            long productId,
            CancellationToken token = default);
    }
}
