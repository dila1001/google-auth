using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //
        // [HttpGet("google")]
        // public async Task GoogleLogin()
        // {
        //     await Request.HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme);
        // }

        // [HttpGet("google")]
        // public IActionResult GoogleLogin()
        // {
        //     return new ChallengeResult(GoogleDefaults.AuthenticationScheme);
        // }
        
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
            // // Process the callback and obtain the access and refresh tokens from Google
            //
            // var accessToken = "" /* obtain the access token */;
            // var refreshToken = "" /* obtain the refresh token */;
            //
            // // Set the access token as an HTTP-only cookie
            // Response.Cookies.Append("AccessToken", accessToken, new CookieOptions
            // {
            //     HttpOnly = true,
            //     Secure = true,    // Set to true if using HTTPS
            //     SameSite = SameSiteMode.Strict, // Adjust based on your requirements
            //     // Additional cookie options can be set here
            // });
            //
            // // Set the refresh token as a non-HTTP-only cookie
            // Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            // {
            //     HttpOnly = false,
            //     Secure = true,    // Set to true if using HTTPS
            //     SameSite = SameSiteMode.Strict, // Adjust based on your requirements
            //     // Additional cookie options can be set here
            // });
            //
            // // Respond with a message or redirect if needed
            // return Ok(new { Message = "Access and refresh tokens set as cookies." });
        }
    }
}
