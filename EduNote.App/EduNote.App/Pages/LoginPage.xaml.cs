using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;
using Xamarin.Forms;

namespace EduNote.App.Pages
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;

            // Only for testing purposes
            viewModel.Authenticate();
        }



        void Handle_Clicked(object sender, System.EventArgs e)
        {
            viewModel.Authenticate();
        }
    }
}
