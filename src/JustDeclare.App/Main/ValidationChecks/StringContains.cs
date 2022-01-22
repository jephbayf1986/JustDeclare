using JustDeclare.Main.Helpers;
using JustDeclare.Models.Enums;
using System;
using System.Text;

namespace JustDeclare.Main.ValidationChecks
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
        {
            var messageBuilder = new StringBuilder("A value of '");

            if (ValueProvided.Length > 10)
                messageBuilder.Append($"{ValueProvided.Substring(0, 10)}...");
            else
                messageBuilder.Append(ValueProvided);

            messageBuilder.Append($"' was provided for {PropertyName}, which ");
            messageBuilder.Append(Invert ? "should" : "should not");
            messageBuilder.Append($"contain the text '{_targetValue}' but ");
            messageBuilder.Append(Invert ? "does not" : "does");

            return messageBuilder.ToString();
        }

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return ValueProvided.IndexOf(_targetValue, _caseSensitivity.ToStringComparison()) >= 0;
        }
    }
}
