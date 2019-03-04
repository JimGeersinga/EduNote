using System;
using System.Collections.Generic;
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
            var s = EduNote.App.App.Container.Resolve<ISectionGroupService>();
            var vm = s.Get(1);
            BindingContext = vm;


        }
    }
}
