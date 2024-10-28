using InventoryService.Api.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(
            IInventoryService inventoryService, 
            ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        /// <summary>
        /// Returns inventory for particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Returns inventory for particular product")]
        [SwaggerResponse(StatusCodes.Status200OK, "Inventory returned")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get([FromRoute] long productId, CancellationToken token = default)
        {
            var result = await _inventoryService.GetInventoryByProductId(productId, token);

            return result.IsSuccess
                ? this.Ok(result.GetValueOrDefault())
                : this.BadRequest(result.Error);
        }
    }
}
