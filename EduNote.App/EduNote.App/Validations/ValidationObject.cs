using System;
using System.Collections.Generic;
using System.Linq;
using EduNote.App.ViewModels;

namespace EduNote.App.Validations
{
    public class ValidationObject<T> : ExtendedBindableObject,IValid
    {
        private readonly List<IValidationRule<T>> validations;
        private List<string> errors;
        private T _value;
        private bool isValid;

        public List<IValidationRule<T>> Validations => validations;

        public List<string> Errors
        {
            get
            {
                return errors;
            }
            set
            {
                errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public ValidationObject()
        {
            isValid = true;
            errors = new List<string>();
            validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> _errors = validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = _errors.ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }
    }
}
