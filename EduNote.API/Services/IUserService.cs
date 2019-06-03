using EduNote.API.EF.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace EduNote.API.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        string GetRefreshToken(string email);
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        void UpdateRefreshToken(string email, string refreshToken);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
