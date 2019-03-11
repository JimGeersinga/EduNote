using System;
using System.Threading.Tasks;

namespace EduNote.App.Services
{
    public interface INavigationService
    {
        Task ShowLogin();
        Task ShowSectionGroup(int id);
        Task ShowSection(int id);
    }
}
