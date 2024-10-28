namespace CartService.Api.Contracts.Responses
{
    public record ProductResponse
    {
        public long ProductId { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public long CategoryId { get; init; }

        public string Sku { get; init; }

        public string Url { get; init; }

        public string Image { get; init; }
    }
}