using JustDeclare.Models.Enums;
using System;

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

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
