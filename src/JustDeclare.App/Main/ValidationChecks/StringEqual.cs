using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class StringEqual : ValidationCheck<string>
    {
        public StringEqual(string value, string targetValue) 
            : base(value)
        {
            _targetValue = targetValue;
        }

        private readonly string _targetValue;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}