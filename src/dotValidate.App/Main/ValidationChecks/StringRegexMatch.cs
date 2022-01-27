using System.Text.RegularExpressions;

namespace dotValidate.Main.ValidationChecks
{
    internal class StringRegexMatch : ValidationCheck<string>
    {
        public StringRegexMatch(string value, string pattern)
            : base(value)
        {
            _regex = new Regex(pattern);
        }

        private Regex _regex;

        protected override string DefaultRuleBreakDescription
            => $"The value was provided for {PropertyName} did not match the expected text pattern";

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return _regex.IsMatch(ValueProvided);
        }
    }
}