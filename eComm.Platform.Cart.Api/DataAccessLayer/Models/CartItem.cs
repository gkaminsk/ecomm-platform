namespace CartService.Api.DataAccessLayer.Models
{
    public class CartItem
    {
        public long CartId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ProductUrl { get; set; }

        public string ProductImage { get; set; }
    }
}
