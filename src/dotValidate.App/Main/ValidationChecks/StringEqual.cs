using dotValidate.Enums;
using dotValidate.Main.Helpers;

namespace dotValidate.Main.ValidationChecks
{
    internal class StringEqual : ValidationCheck<string>
    {
        public StringEqual(string value, string targetValue, Case caseSensitivity = Case.Sensitive) 
            : base(value)
        {
            _targetValue = targetValue;
            _caseSensitivity = caseSensitivity;
        }

        private readonly string _targetValue;
        private readonly Case _caseSensitivity;

        protected override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but {Should} be '{_targetValue}'{OrWithSensitivity(_caseSensitivity)}.";

        protected override bool GetTestResult()
            => _targetValue.Equals(ValueProvided, _caseSensitivity.ToStringComparison());
    }
}