using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class StringStartsWith : ValidationCheck<string>
    {
        public StringStartsWith(string value, string targetValue, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
            : base(value)
        {
            _targetValue = targetValue;
            _stringComparison = stringComparison;
        }

        private readonly string _targetValue;
        private readonly StringComparison _stringComparison;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
