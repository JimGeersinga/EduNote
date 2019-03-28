using EduNote.App.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduNote.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionListPage : ContentPage
    {
        private QuestionListViewModel _viewModel;
        public QuestionListViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                BindingContext = _viewModel;
            }
        }

        public QuestionListPage()
        {
            try
            {
                ViewModel = new QuestionListViewModel();
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
            ViewModel.LoadQuestions();
        }
    }
}