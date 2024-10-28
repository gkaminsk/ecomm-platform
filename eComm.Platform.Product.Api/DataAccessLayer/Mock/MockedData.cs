using ProductService.Api.DataAccessLayer.Models;

namespace ProductService.Api.DataAccessLayer.Mock
{
    public static class MockedData
    {
        internal static List<Product> AllProducts =>
        [
            new Product
            {
                ProductId = 1,
                Name = "Pork - Shoulder",
                Description = "Farmer John Fresh Bone In Pork Shoulder Picnic Roast is a 100% all-natural gluten free pork that will make your mouth water.",
                CategoryId = 1,
                Price = 9.46m,
                Sku = "572260245-0",
                Url = "products/1",
                Image = "http://cdn.theoneshop.com/files/dummyimage/1.png",
            },
            new Product
            {
                ProductId = 2,
                Name = "Island Oasis - Lemonade",
                Description = "Indulge in the refreshing taste of real lemons and pure cane sugar with Island Oasis 1 Liter Lemonade Puree Beverage Mix. Whether you're crafting a lemonade smoothie or cocktail, this mix provides the perfect balance of sweetness and tartness.",
                CategoryId = 1,
                Price = 4.98m,
                Sku = "683682727-4",
                Url = "products/2",
                Image = "http://cdn.theoneshop.com/files/dummyimage/2.png",
            },
            new Product
            {
                ProductId = 3,
                Name = "Tomato Soup - Campbells",
                Description = "Cozy up with a steamy bowl of Campbell's Condensed Tomato Soup. A family favorite for generations, this vegan soup is crafted with six farm-grown tomatoes in every can.",
                CategoryId = 1,
                Price = 1.26m,
                Sku = "298185163-2",
                Url = "products/3",
                Image = "http://cdn.theoneshop.com/files/dummyimage/3.png",
            },
            new Product
            {
                ProductId = 4,
                Name = "Pastry - Key Lime Pie",
                Description = "EDWARDS DESSERTS - Exceptional indulgences made effortless! No matter how you slice our decadent, velvety layers and fresh-from-the-oven cookie crumb crust, our frozen pies are meticulously whipped, sprinkled, and drizzled to extravagant perfection.",
                CategoryId = 1,
                Price = 7.32m,
                Sku = "807232912-X",
                Url = "products/4",
                Image = "http://cdn.theoneshop.com/files/dummyimage/4.png",
            },
            new Product
            {
                ProductId = 5,
                Name = "Bagel - Sesame Seed Presliced",
                Description = "Start your day off right with Thomas’ Everything Bagels. These everything bagels are crunchy on the outside, soft on the inside and savory all over when lightly toasted for taste beyond compare.",
                CategoryId = 1,
                Price = 0.70m,
                Sku = "042597065-5",
                Url = "products/5",
                Image = "http://cdn.theoneshop.com/files/dummyimage/5.png",
            },
            new Product
            {
                ProductId = 101,
                Name = "Samsung Galaxy A35 5G A Series 128GB Unlocked Android Cell Phone, US Version, 2024, Awesome Navy",
                Description = "Packed with amazing capabilities, Galaxy A35 5G is designed to bring out the best in every moment. From mountain adventures to local hangouts, the pro-grade camera of A35 5G captures mind-blowing details.",
                CategoryId = 2,
                Price = 329.66m,
                Sku = "211682182-7",
                Url = "products/101",
                Image = "http://cdn.theoneshop.com/files/dummyimage/101.png",
            },
            new Product
            {
                ProductId = 102,
                Name = "Sony Xperia 1 V 5G XQ-DQ72 Dual SIM 512GB ROM 12GB RAM GSM Unlocked – Silver",
                Description = "The Xperia 1 V's revolutionary Exmor T for mobile image sensor has an innovative 2-Layer Transistor Pixel – one for the photodiode and one for the phototransistor – 2x better than its predecessor in low light 9,10, with less noise.",
                CategoryId = 2,
                Price = 1059.99m,
                Sku = "279641339-X",
                Url = "products/102",
                Image = "http://cdn.theoneshop.com/files/dummyimage/102.png",
            },
            new Product
            {
                ProductId = 103,
                Name = "Apple iPhone 15 Pro Max, 256GB, White",
                Description = "So strong. So light. So Pro. The iPhone 15 Pro Max in White with 256GB of internal storage is the first iPhone to feature an aerospace‑grade titanium design, using the same alloy that spacecraft use for missions to Mars, making this our lightest Pro model ever.",
                CategoryId = 2,
                Price = 1199.00m,
                Sku = "648982788-3",
                Url = "products/103",
                Image = "http://cdn.theoneshop.com/files/dummyimage/103.png",
            }
        ];
    }
}