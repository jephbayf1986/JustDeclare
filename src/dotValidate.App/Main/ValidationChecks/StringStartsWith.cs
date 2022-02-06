using dotValidate.Enums;
using dotValidate.Main.Helpers;

namespace dotValidate.Main.ValidationChecks
{
    internal class StringStartsWith : ValidationCheck<string>
    {
        public StringStartsWith(string value, string targetValue, Case caseSensitivity = Case.Sensitive)
            : base(value)
        {
            _targetValue = targetValue;
            _caseSensitivity = caseSensitivity;
        }

        private readonly string _targetValue;
        private readonly Case _caseSensitivity;

        protected internal override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but this {Should} start with the text '{_targetValue}'{OrWithSensitivity(_caseSensitivity)}.";

        protected internal override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return ValueProvided.StartsWith(_targetValue, _caseSensitivity.ToStringComparison());
        }
    }
}
