using CSharpFunctionalExtensions;
using InventoryService.Api.Contracts.Responses;

namespace InventoryService.Api.Infrastructure.Services.Abstractions
{
    public interface IInventoryService
    {
        Task<Result<InventoryResponse?>> GetInventoryByProductId(long productId, CancellationToken token = default);
    }
}