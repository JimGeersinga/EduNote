using System;
using System.Threading.Tasks;
using EduNote.App.Pages;
using EduNote.App.Services;

namespace EduNote.App.NavigationServices
{
    public class NavigationService : INavigationService
    {


        public async Task ShowLogin()
        {
            await App.Page.Navigation.PushAsync(new LoginPage());
        }

        public async Task ShowSection(int id)
        {
            await App.Page.Navigation.PushAsync(new SectionGroupPage());
        }

        public async Task ShowSectionGroup(int id)
        {
            await App.Page.Navigation.PushAsync(new SectionGroupPage());
        }
    }
}
