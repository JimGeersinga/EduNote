using Autofac;
using EduNote.App.MockServices;
using EduNote.App.NavigationServices;
using EduNote.App.Pages;
using EduNote.App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EduNote.App
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }
        public static Page Page { get; set; }
        public App()
        {
            InitializeIOCContainer();
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            Page = MainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        public static void ShowLoginPage()
        {
            Page = new NavigationPage(new LoginPage());

        }

        public static void ShowMainPage()
        {
            App.Current.MainPage = new MainPage();
            Page = App.Current.MainPage;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        private void InitializeIOCContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ApiService>().As<IApiService>().SingleInstance();
            builder.RegisterType<MockSectionService>().As<ISectionService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<MockQuestionService>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<MockNoteService>().As<INoteService>().SingleInstance();
            Container = builder.Build();

        }
    }
}
