using System;
using EduNote.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduNote.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionDetailsPage : ContentPage
    {
        private QuestionViewModel _viewModel;
        public QuestionViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                BindingContext = _viewModel;
            }
        }
       
        private readonly int _questionId;

        public QuestionDetailsPage(int questionId)
        {
            try
            {
                _questionId = questionId;
                ViewModel = new QuestionViewModel();
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
            ViewModel.LoadQuestion(_questionId);
        }
    }
}
