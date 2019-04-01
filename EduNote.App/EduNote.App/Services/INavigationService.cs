using System;
using System.Threading.Tasks;

namespace EduNote.App.Services
{
    public interface INavigationService
    {
        Task ShowRoot();
        Task ShowLogin();
        Task ShowSectionList(long? sectionId = null);
    }
}
