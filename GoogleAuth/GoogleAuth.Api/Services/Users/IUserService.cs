using System.Security.Claims;
using GoogleAuth.Api.Models;

namespace GoogleAuth.Api.Services.Users;

public interface IUserService
{
    User GetUserInfo(ClaimsPrincipal user);
}