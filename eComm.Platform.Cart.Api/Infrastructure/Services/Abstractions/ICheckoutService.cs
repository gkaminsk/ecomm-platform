using CSharpFunctionalExtensions;

namespace CartService.Api.Infrastructure.Services.Abstractions
{
    public interface ICheckoutService
    {
        Task<Result<string>> CheckoutCart(CancellationToken token);
    }
}
