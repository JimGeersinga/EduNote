using System;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface IUserService
    {
        string Authenticate(string userName, string password);
        UserViewModel Get();
    }
}
