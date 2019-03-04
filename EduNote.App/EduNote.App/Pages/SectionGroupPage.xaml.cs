using Autofac;
using EduNote.App.Services;
using EduNote.App.ViewModels;
using Xamarin.Forms;

namespace EduNote.App.Pages
{
    public partial class SectionGroupPage : ContentPage
    {
        public SectionGroupPage()
        {
            InitializeComponent();
            ISectionGroupService s = EduNote.App.App.Container.Resolve<ISectionGroupService>();
            SectionGroupViewModel vm = s.Get(1);
            BindingContext = vm;            
        }
    }
}
