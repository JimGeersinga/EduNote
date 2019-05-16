using System;
using System.Threading.Tasks;
using EduNote.App.Pages;
using EduNote.App.Services;
using Xamarin.Forms;

namespace EduNote.App.NavigationServices
{
    public class NavigationService : INavigationService
    {
        public async Task ShowRoot()
        {
            App.Current.MainPage = new NavigationPage(new SectionListPage());
            App.Page = App.Current.MainPage;
            await App.Page.Navigation.PopToRootAsync();
        }

        public async Task ShowLogin()
        {
            await App.Page.Navigation.PushAsync(new LoginPage());
        }

        public async Task ShowSectionList(long? sectionId = null)
        {
            await App.Page.Navigation.PushAsync(new SectionListPage());
        }
    }
}
