namespace CartService.Api.Contracts.Responses
{
    public record CartResponse
    {
        public long? CartId { get; init; }

        public IEnumerable<CartItemResponse>? CartItems { get; init; }

        public decimal TotalPrice { get; init; }
    }
}
