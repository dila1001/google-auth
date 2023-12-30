using Microsoft.AspNetCore.Mvc;

namespace GoogleAuth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicController : ControllerBase
{
    [HttpGet("Test")]
    public IActionResult Test()
    {
        return new JsonResult(new { Message = "Public data"});
    }
}