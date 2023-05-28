using Microsoft.AspNetCore.Mvc;
using Sale.Application.DTO.Products;
using Sale.Application.Services.Products;

namespace Sale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateProductDTO dto, CancellationToken cancellationToken)
            => Ok(await _productService.CreateAsync(dto, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> Update(AddOrUpdateProductDTO dto, CancellationToken cancellationToken)
            => Ok(await _productService.UpdateAsync(dto, cancellationToken));

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _productService.DeleteAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SearchOrQuery([FromQuery] string @param, CancellationToken cancellationToken)
        {
            var data = await _productService.SearchAsync(param, cancellationToken);

            if (!data.Any()) return NotFound();

            return Ok(data);
        }
    }
}
