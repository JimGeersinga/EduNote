using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
using System.Net;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;

using EduNote.App.Droid.Clients;

namespace EduNote.App.Droid
{
    [Activity(Label = "EduNote.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            var container = new SimpleContainer();
            container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
            container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);

            try
            {
                Xamarin.Forms.DependencyService.Register<EduHttpClient>();
                DependencyService.Register<MediaPicker>();
                Resolver.SetResolver(container.GetResolver());
                global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");

                
            }
            catch
            {

            }
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}