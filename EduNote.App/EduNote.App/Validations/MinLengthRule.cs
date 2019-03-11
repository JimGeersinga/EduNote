using System;
namespace EduNote.App.Validations
{
    public class MinLengthRule<T> : IValidationRule<T>
    {
        private int length{get;set;} 
        public MinLengthRule(string message, int _length)
        {
            ValidationMessage = message;
            this.length = _length;
        }
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            Console.WriteLine("Yo " + value.ToString());
            if (value == null || value.ToString().Length < length)
            {
                return false;
            }
            return true;
        }
    }
}
