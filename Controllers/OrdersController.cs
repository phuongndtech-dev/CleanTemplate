using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpGet("")]
    public OkResult Get()
    {
        return Ok();
    }
}
