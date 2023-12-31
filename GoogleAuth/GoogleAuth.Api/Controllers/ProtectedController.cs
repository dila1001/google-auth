using GoogleAuth.Api.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuth.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProtectedController : ControllerBase
{
    private readonly IUserService _userService;

    public ProtectedController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("Test")]
    public IActionResult Test()
    {
        var userInfo = _userService.getUserInfo(User);
        return Ok(userInfo);
    }
}