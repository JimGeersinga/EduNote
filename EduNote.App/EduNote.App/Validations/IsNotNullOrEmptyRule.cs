using System;
namespace EduNote.App.Validations
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public IsNotNullOrEmptyRule(string message)
        {
            _message = message;
        }
        private string _message;
        public string ValidationMessage { get => _message; set => _message = value; }

        public bool Check(T value)
        {
            if(value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
