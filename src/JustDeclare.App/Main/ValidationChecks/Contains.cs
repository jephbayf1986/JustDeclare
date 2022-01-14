using System;
using System.Text;

namespace JustDeclare.Main.ValidationChecks
{
    internal class Contains : ValidationCheck<string>
    {
        public Contains(string value, string targetValue, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase, bool invert = false)
            : base(value)
        {
            _targetValue = targetValue;
            _invert = invert;
            _stringComparison = stringComparison;
        }

        private readonly bool _invert;
        private readonly string _targetValue;
        private readonly StringComparison _stringComparison;

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
            messageBuilder.Append(_invert ? "should" : "should not");
            messageBuilder.Append($"contain the text '{_targetValue}' but ");
            messageBuilder.Append(_invert ? "does not" : "does");

            return messageBuilder.ToString();
        }

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return _invert;

            var index = ValueProvided.IndexOf(_targetValue, _stringComparison);

            if (_invert)
                return index < 0;

            return index >= 0;
        }
    }
}
