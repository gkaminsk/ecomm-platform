using InventoryService.Api.Contracts.Responses;
using InventoryService.Api.DataAccessLayer.Models;

namespace InventoryService.Api.Infrastructure.Extensions
{
    public static class InventoryExtensions
    {
        public static InventoryResponse ToInventoryResponse(this Inventory input)
        {
            return new InventoryResponse(input.ProductId, input.TotalQuantity);
        }
    }
}
