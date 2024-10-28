using InventoryService.Api.DataAccessLayer.Models;

namespace InventoryService.Api.Infrastructure.Repositories.Abstractions
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>?> GetInventoriesByProductIds(IEnumerable<long> productIds, CancellationToken token = default);

        Task<Inventory?> GetInventoryByProductId(long productId, CancellationToken token = default);
    }
}