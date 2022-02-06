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

        protected internal override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, which {Should} match the following text pattern '{_regex.ToString()}'";

        protected internal override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            return _regex.IsMatch(ValueProvided);
        }
    }
}