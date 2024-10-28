using InventoryService.Api.Contracts.Responses;
using InventoryService.Api.DataAccessLayer.Models;

namespace InventoryService.Api.DataAccessLayer.Mock
{
    public static class MockedData
    {
        internal static List<Inventory> AllInventory =>
        [
            new Inventory { ProductId = 1, TotalQuantity = 5 },
            new Inventory { ProductId = 2, TotalQuantity = 12 },
            new Inventory { ProductId = 3, TotalQuantity = 20 },
            new Inventory { ProductId = 4, TotalQuantity = 3 },
            new Inventory { ProductId = 5, TotalQuantity = 50 },
            new Inventory { ProductId = 101, TotalQuantity = 7 },
            new Inventory { ProductId = 102, TotalQuantity = 1 },
            new Inventory { ProductId = 103, TotalQuantity = 2 }
        ];
    }
}
