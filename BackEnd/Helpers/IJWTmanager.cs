using BackEnd.DTO;
using FullStack.Models;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Helpers.Interfaces
{
    public interface IJWTmanager
    {
        string GetIP();
         UserClaims GetUserClaims();
         UserClaims GetUserClaims(HttpContext httpContext);
         string GenerateJwtToken(User user, int expireInHours = 0);
    }
}