using Microsoft.AspNetCore.Mvc;
using Sale.Application.DTO.Shops;
using Sale.Application.Services.Shops;

namespace Sale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateShopDTO dto, CancellationToken cancellationToken)
           => Ok(await _shopService.CreateAsync(dto, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> Update(AddOrUpdateShopDTO dto, CancellationToken cancellationToken)
            => Ok(await _shopService.UpdateAsync(dto, cancellationToken));

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _shopService.DeleteAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SearchOrQuery([FromQuery] string @param, CancellationToken cancellationToken)
        {
            var data = await _shopService.SearchAsync(param, cancellationToken);

            if(!data.Any()) return NotFound();

            return Ok(data);
        }
    }
}
