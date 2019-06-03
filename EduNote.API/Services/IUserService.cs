using EduNote.API.EF.Models;
using System.Security.Claims;

namespace EduNote.API.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        string GenerateToken(User user);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
