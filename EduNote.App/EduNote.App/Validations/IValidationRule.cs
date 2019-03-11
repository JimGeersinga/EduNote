using System;
namespace EduNote.App.Validations
{
    public interface IValidationRule<T>
    {
        bool Check(T value);
        string ValidationMessage { get; set; }
    }
}
