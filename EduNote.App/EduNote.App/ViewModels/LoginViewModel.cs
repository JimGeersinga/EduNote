using System;
using System.Windows.Input;
using Autofac;
using EduNote.App.Services;
using EduNote.App.Validations;
using Xamarin.Forms;

namespace EduNote.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            navigation = App.Container.Resolve<INavigationService>();
            userName = new ValidationObject<string>();
            AddValidations();
        }
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        private ValidationObject<string> userName;
        public ValidationObject<string> UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }


        private Color userNameColor;
        public Color UserNameColor
        {
            get => userNameColor == null ? Color.Black : userNameColor;
            set
            {
                userNameColor = value;
                OnPropertyChanged();

            }
        }


        public void Authenticate()
        {
            if(userName.IsValid)
            {
                MoveToSection();
            }
            else
            {

            }
        }

        private string password;
        public string Password
        {
            get => string.IsNullOrWhiteSpace(password) ? "" : password;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                    OnPropertyChanged();
                }

            }
        }

        private INavigationService navigation = null;




        public void MoveToSection()
        {
            navigation.ShowSection(1);
        }


        private bool ValidateUserName()
        {
            return userName.Validate();
        }



        private void AddValidations()
        {
            userName.Validations.Add(new MinLengthRule<string>("Min length 10.", 10));
        }
    }
}
