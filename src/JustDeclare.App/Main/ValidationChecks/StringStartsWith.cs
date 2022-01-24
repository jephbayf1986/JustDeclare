using JustDeclare.Main.Helpers;
using JustDeclare.Models.Enums;

namespace JustDeclare.Main.ValidationChecks
{
    internal class StringStartsWith : ValidationCheck<string>
    {
        public StringStartsWith(string value, string targetValue, MatchCase caseSensitivity = MatchCase.Sensitive)
            : base(value)
        {
            _targetValue = targetValue;
            _caseSensitivity = caseSensitivity;
        }

        private readonly string _targetValue;
        private readonly MatchCase _caseSensitivity;

        protected override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but this {Should} start with the text '{_targetValue}'{OrWithSensitivity(_caseSensitivity)}.";

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return ValueProvided.StartsWith(_targetValue, _caseSensitivity.ToStringComparison());
        }
    }
}
