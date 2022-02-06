using dotValidate.Enums;
using dotValidate.Main.Helpers;

namespace dotValidate.Main.ValidationChecks
{
    internal class StringContains : ValidationCheck<string>
    {
        public StringContains(string value, string targetValue, Case caseSensitivity = Case.Sensitive)
            : base(value)
        {
            _targetValue = targetValue;
            _caseSensitivity = caseSensitivity;
        }

        private readonly string _targetValue;
        private readonly Case _caseSensitivity;

        protected internal override string DefaultRuleBreakDescription
            => GetRuleBreakMessage();

        private string GetRuleBreakMessage()
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but this {Should} contain the text '{_targetValue}'{OrWithSensitivity(_caseSensitivity)}.";

        protected internal override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return ValueProvided.IndexOf(_targetValue, _caseSensitivity.ToStringComparison()) >= 0;
        }
    }
}
