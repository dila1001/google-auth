using System.Security.Claims;
using GoogleAuth.Api.Models;

namespace GoogleAuth.Api.Services.Users;

public class UserService : IUserService
{

    public User GetUserInfo(ClaimsPrincipal user)
    {

        var userInfo = new User(user.FindFirst(ClaimTypes.NameIdentifier)!.Value,
            user.FindFirst(ClaimTypes.GivenName)!.Value, user.FindFirst(ClaimTypes.Surname)!.Value,
            user.FindFirst(ClaimTypes.Email)!.Value);

        return userInfo;
    }
}