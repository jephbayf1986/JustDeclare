using dotValidate.Main.Helpers;
using dotValidate.Models.Enums;

namespace dotValidate.Main.ValidationChecks
{
    internal class StringContains : ValidationCheck<string>
    {
        public StringContains(string value, string targetValue, MatchCase caseSensitivity = MatchCase.Sensitive)
            : base(value)
        {
            _targetValue = targetValue;
            _caseSensitivity = caseSensitivity;
        }

        private readonly string _targetValue;
        private readonly MatchCase _caseSensitivity;

        protected override string DefaultRuleBreakDescription
            => GetRuleBreakMessage();

        private string GetRuleBreakMessage()
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but this {Should} contain the text '{_targetValue}'{OrWithSensitivity(_caseSensitivity)}.";

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return ValueProvided.IndexOf(_targetValue, _caseSensitivity.ToStringComparison()) >= 0;
        }
    }
}
