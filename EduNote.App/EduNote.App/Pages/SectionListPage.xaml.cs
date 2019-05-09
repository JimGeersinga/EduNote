using EduNote.App.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduNote.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionListPage : ContentPage
    {
        private SectionListViewModel _viewModel;
        public SectionListViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                BindingContext = _viewModel;
            }
        }

        private readonly long? _sectionId;

        public SectionListPage()
        {
            try
            {
                _sectionId = null;
                ViewModel = new SectionListViewModel();
                InitializeComponent();               
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadSections(_sectionId);
        }

        private void TextCell_Tapped(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SectionListPage());
        }
    }
}
