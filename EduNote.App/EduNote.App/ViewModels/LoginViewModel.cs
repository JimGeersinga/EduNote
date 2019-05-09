using Autofac;
using EduNote.App.Services;
using EduNote.App.Validations;
using System.Windows.Input;
using Xamarin.Forms;

namespace EduNote.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            _navigation = App.Container.Resolve<INavigationService>();
            userName = new ValidationObject<string>();
            AddValidations();
        }
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        
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
        private bool _formValid = false;
        public bool FormValid
        {
            get => _formValid;
            set
            {
                _formValid = value;
                OnPropertyChanged();
            }
        }

        private Color _userNameColor;
        public Color UserNameColor
        {
            get => _userNameColor == null ? Color.Black : _userNameColor;
            set
            {
                _userNameColor = value;
                OnPropertyChanged();

            }
        }


        public void Authenticate()
        {
            Message = string.Empty;
            if (userName.IsValid)
            {
                //GoToRoot();
                App.ShowMainPage();
            }
            else
            {
                Message = "Inloggen mislukt."; 
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private readonly INavigationService _navigation;


        //public void GoToRoot()
        //{
        //    _navigation.ShowRoot();
        //}

        //public void MoveToSection()
        //{
        //    _navigation.ShowSectionList();
        //}


        private bool ValidateUserName()
        {
            FormValid = userName.Validate();
            return userName.Validate();
        }



        private void AddValidations()
        {
            userName.Validations.Add(new MinLengthRule<string>("Min length 10.", 10));
        }
    }
}
