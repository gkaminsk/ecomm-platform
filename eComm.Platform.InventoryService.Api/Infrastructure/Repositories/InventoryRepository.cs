using InventoryService.Api.DataAccessLayer.Mock;
using InventoryService.Api.DataAccessLayer.Models;
using InventoryService.Api.Infrastructure.Repositories.Abstractions;

namespace InventoryService.Api.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public async Task<Inventory?> GetInventoryByProductId(
            long productId,
            CancellationToken token = default)
        {
            var result = MockedData.AllInventory
                .Where(x => x.ProductId == productId)
                .SingleOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Inventory>?> GetInventoriesByProductIds(
            IEnumerable<long> productIds,
            CancellationToken token = default)
        {
            var result = MockedData.AllInventory
                .Where(x => productIds.ToList().Contains(x.ProductId));

            return await Task.FromResult(result);
        }
    }
}
