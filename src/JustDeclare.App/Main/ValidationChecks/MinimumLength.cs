using JustDeclare.Models;

namespace JustDeclare.Main.ValidationChecks
{
    internal class MinimumLength : ValidationCheck<string>
    {
        public MinimumLength(string value, int minLength)
            : base(value)
        {
            _minLength = minLength;
        }

        private int _minLength;

        protected override string DefaultRuleBreakDescription
            => GetRuleBreakMessage();

        private string GetRuleBreakMessage()
        {
            var length = ValueProvided.Length;

            if (string.IsNullOrWhiteSpace(ValueProvided))
                return $"A value of {length} characters was provided for {PropertyName}, but the shortest allowed length is {_minLength} characters.";

            if (length > 0 && length < 11)
                return $"A value of '{ValueProvided}' ({length} characters) was provided for {PropertyName}, but the shortest allowed length is {_minLength} characters.";

            return $"A value of '{ValueProvided.Substring(0, 10)}...' ({length} characters) was provided for {PropertyName}, but the shortest allowed length is {_minLength} characters.";
        }

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            if (ValueProvided.Length < _minLength)
                return false;

            return true;
        }
    }
}