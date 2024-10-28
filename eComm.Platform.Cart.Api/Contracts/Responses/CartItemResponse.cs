namespace CartService.Api.Contracts.Responses
{
    public record CartItemResponse
    {
        public long CartId { get; init; }

        public long ProductId { get; init; }

        public string ProductName { get; init; }

        public decimal ProductPrice { get; init; }

        public int Quantity { get; init; }

        public string ProductUrl { get; init; }

        public string ProductImage { get; init; }
    }
}
