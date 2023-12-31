using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        [HttpGet("google")]
        [HttpGet("google/callback")]
        public async Task<IActionResult> GoogleCallback(string returnUrl)
        {
            var authenticateResult = await Request.HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            
            if (!authenticateResult.Succeeded)
            {
                return new ChallengeResult(GoogleDefaults.AuthenticationScheme);
            }
            
            var claims = authenticateResult.Principal.Identities.FirstOrDefault()!.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            
            return LocalRedirect(returnUrl);
        }
        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignOutAsync(GoogleDefaults.AuthenticationScheme);
            
            return Ok();
        }
    }
}
