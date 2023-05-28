using Microsoft.AspNetCore.Mvc;
using Sale.Application.DTO.Customers;
using Sale.Application.Services.Customers;

namespace Sale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateCustomerDTO dto, CancellationToken cancellationToken)
            => Ok(await _customerService.CreateAsync(dto, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> Update(AddOrUpdateCustomerDTO dto, CancellationToken cancellationToken)
            => Ok(await _customerService.UpdateAsync(dto, cancellationToken));

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _customerService.DeleteAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? @param, CancellationToken cancellationToken)
        {
            var data = await _customerService.SearchAsync(param, cancellationToken);

            if(!data.Any()) return NotFound();

            return Ok(data);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var data = await _customerService.GetAllAsync(cancellationToken);

            if (!data.Any()) return NotFound();

            return Ok(data);
        }
    }
}
