using Microsoft.AspNetCore.Mvc;
using ProductService.Api.Infrastructure;
using ProductService.Api.Infrastructure.Services.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService, 
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Returns product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Returns product by Id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product returned")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductById(
            [FromRoute] long productId, 
            CancellationToken token = default)
        {
            var result = await _productService.GetProductById(productId, token);

            return result.IsSuccess
                ? this.Ok(result.GetValueOrDefault())
                : this.UnprocessableEntity(result.Error);
        }

        /// <summary>
        /// Returns products by Ids list
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Returns products by Ids list")]
        [SwaggerResponse(StatusCodes.Status200OK, "Products returned")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("products")]
        public async Task<IActionResult> GetProductsByIds(
            [FromBody] IEnumerable<long> productIds, 
            CancellationToken token = default)
        {
            var result = await _productService.GetProductsByIds(productIds, token);

            return result.IsSuccess
                ? this.Ok(result.GetValueOrDefault())
                : this.UnprocessableEntity(result.Error);
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="token"></param>
        /// <returns></returns>        
        [SwaggerOperation(Description = "Returns all products")]
        [SwaggerResponse(StatusCodes.Status200OK, "Products returned")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("products-all")]
        public async Task<IActionResult> GetProducts(
            [FromQuery] int pageSize = Consts.DefaultPageSize, 
            [FromQuery] int page = Consts.DefaultPageNumber, 
            CancellationToken token = default)
        {
            var result = await _productService.GetProducts(pageSize, page, token);

            return result.IsSuccess
                ? this.Ok(result.GetValueOrDefault())
                : this.UnprocessableEntity(result.Error);
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="name"></param>
        /// <param name="categoryId"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerOperation(Description = "Search for products")]
        [SwaggerResponse(StatusCodes.Status200OK, "Products returned")]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("products")]
        public async Task<IActionResult> Search(
            [FromQuery] string? name,
            [FromQuery] int? categoryId,
            [FromQuery] int pageSize = Consts.DefaultPageSize,
            [FromQuery] int page = Consts.DefaultPageNumber,
            CancellationToken token = default)
        {
            var result = await _productService.SearchProduct(name, categoryId, pageSize, page, token);

            return result.IsSuccess
                ? this.Ok(result.GetValueOrDefault())
                : this.UnprocessableEntity(result.Error);
        }
    }
}