namespace ProductService.Api.DataAccessLayer.Models
{
    public class Product
    {
        public long ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public long CategoryId { get; set; }

        public string Sku { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }
    }
}
