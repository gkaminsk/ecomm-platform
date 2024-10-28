namespace ProductService.Api.Contracts.Responses
{
    public record ProductsResponse
    {
        public IEnumerable<ProductResponse>? Products { get; init; }

        public int TotalCount { get; init; }
    }
}
