using EduNote.API.EF.Models;

namespace EduNote.API.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        string GenerateToken(User user);
    }
}
