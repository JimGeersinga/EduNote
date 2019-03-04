using System;
using Autofac;
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
        public App()
        {
            InitializeComponent();
            MainPage = new SectionGroupPage();
        }
        static App()
        {
            InitializeIOCContainer();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        private static void InitializeIOCContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MockSectionGroupService>().As<ISectionGroupService>().SingleInstance();
            builder.RegisterType<MockSectionService>().As<ISectionService>().SingleInstance();
            Container = builder.Build();

        }
    }
}
