using CartService.Api.Contracts.Responses;

namespace CartService.Api.DataAccessLayer.Mock
{
    public class MockedData
    {
        internal static List<ProductResponse> AllProducts =>
        [
            new ProductResponse
            {
                ProductId = 1,
                Name = "Pork - Shoulder",
                CategoryId = 1,
                Price = 9.46m,
                Sku = "572260245-0",
                Url = "products/1",
                Image = "http://cdn.theoneshop.com/files/dummyimage/1.png",
            },
            new ProductResponse
            {
                ProductId = 2,
                Name = "Island Oasis - Lemonade",
                CategoryId = 1,
                Price = 4.98m,
                Sku = "683682727-4",
                Url = "products/2",
                Image = "http://cdn.theoneshop.com/files/dummyimage/2.png",
            },
            new ProductResponse
            {
                ProductId = 3,
                Name = "Tomato Soup - Campbells",
                CategoryId = 1,
                Price = 1.26m,
                Sku = "298185163-2",
                Url = "products/3",
                Image = "http://cdn.theoneshop.com/files/dummyimage/3.png",
            },
            new ProductResponse
            {
                ProductId = 4,
                Name = "Pastry - Key Lime Pie",
                CategoryId = 1,
                Price = 7.32m,
                Sku = "807232912-X",
                Url = "products/4",
                Image = "http://cdn.theoneshop.com/files/dummyimage/4.png",
            },
            new ProductResponse
            {
                ProductId = 5,
                Name = "Bagel - Sesame Seed Presliced",
                CategoryId = 1,
                Price = 0.70m,
                Sku = "042597065-5",
                Url = "products/5",
                Image = "http://cdn.theoneshop.com/files/dummyimage/5.png",
            },
            new ProductResponse
            {
                ProductId = 101,
                Name = "Samsung Galaxy A35 5G A Series 128GB Unlocked Android Cell Phone, US Version, 2024, Awesome Navy",
                CategoryId = 2,
                Price = 329.66m,
                Sku = "211682182-7",
                Url = "products/101",
                Image = "http://cdn.theoneshop.com/files/dummyimage/101.png",
            },
            new ProductResponse
            {
                ProductId = 102,
                Name = "Sony Xperia 1 V 5G XQ-DQ72 Dual SIM 512GB ROM 12GB RAM GSM Unlocked – Silver",
                CategoryId = 2,
                Price = 1059.99m,
                Sku = "279641339-X",
                Url = "products/102",
                Image = "http://cdn.theoneshop.com/files/dummyimage/102.png",
            },
            new ProductResponse
            {
                ProductId = 103,
                Name = "Apple iPhone 15 Pro Max, 256GB, White",
                CategoryId = 2,
                Price = 1199.00m,
                Sku = "648982788-3",
                Url = "products/103",
                Image = "http://cdn.theoneshop.com/files/dummyimage/103.png",
            }
        ];

        internal static List<InventoryResponse> AllInventory =>
        [
            new InventoryResponse(ProductId:1, TotalQuantity:5),
            new InventoryResponse(ProductId:2, TotalQuantity:12),
            new InventoryResponse(ProductId:3, TotalQuantity:20),
            new InventoryResponse(ProductId:4, TotalQuantity:3),
            new InventoryResponse(ProductId:5, TotalQuantity:50),
            new InventoryResponse(ProductId:101, TotalQuantity:7),
            new InventoryResponse(ProductId:102, TotalQuantity:1),
            new InventoryResponse(ProductId:103, TotalQuantity:2),
        ];
    }
}
