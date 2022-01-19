using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class BoolEqual : ValidationCheck<bool?>
    {
        public BoolEqual(bool? value, bool targetValue)
            : base(value)
        {
            _targetValue = targetValue;
        }

        private readonly bool _targetValue;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
