using System.Security.Claims;
using GoogleAuth.Api.Models;

namespace GoogleAuth.Api.Services.Users;

public class UserService : IUserService
{

    public User getUserInfo(ClaimsPrincipal user)
    {

        var userInfo = new User()
        {
            Id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            Name = user.FindFirst(ClaimTypes.GivenName)?.Value,
            Surname = user.FindFirst(ClaimTypes.Surname)?.Value,
            Email = user.FindFirst(ClaimTypes.Email)?.Value
        };

        return userInfo;
    }
}