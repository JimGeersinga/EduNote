using System;
namespace EduNote.App.Validations
{
    public class RangeRule : IValidationRule<int>
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public RangeRule(string message, int min, int max)
        {
            ValidationMessage = message;
            Min = min;
            Max = max;
        }

        public string ValidationMessage { get; set; }

        public bool Check(int value)
        {
            return value <= Max && value >= Min;
        }
    }
}
