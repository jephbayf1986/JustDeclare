using System.Text.RegularExpressions;

namespace JustDeclare.Main.ValidationChecks
{
    internal class RegexMatch : ValidationCheck<string>
    {
        public RegexMatch(string value, string pattern)
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