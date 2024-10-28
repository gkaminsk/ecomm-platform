using CSharpFunctionalExtensions;
using InventoryService.Api.Contracts.Responses;
using InventoryService.Api.Infrastructure.Extensions;
using InventoryService.Api.Infrastructure.Repositories.Abstractions;
using InventoryService.Api.Infrastructure.Services.Abstractions;

namespace InventoryService.Api.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(
            IInventoryRepository inventoryRepository,
            ILogger<InventoryService> logger)
        {
            _inventoryRepository = inventoryRepository;
            _logger = logger;
        }

        public async Task<Result<InventoryResponse?>> GetInventoryByProductId(
            long productId,
            CancellationToken token = default)
        {
            var inventory = await _inventoryRepository.GetInventoryByProductId(productId, token);

            return Result.Success(inventory?.ToInventoryResponse());
        }
    }
}
