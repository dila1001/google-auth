using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuth.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProtectedController : ControllerBase
{
    [HttpGet("Test")]
    public IActionResult Test()
    {
        return new JsonResult(new { Message = "Secret data, shh"});
    }
}