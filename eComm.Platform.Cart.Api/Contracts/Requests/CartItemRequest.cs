namespace CartService.Api.Contracts.Requests
{
    public record CartItemRequest(long ProductId, int Quantity);
}
