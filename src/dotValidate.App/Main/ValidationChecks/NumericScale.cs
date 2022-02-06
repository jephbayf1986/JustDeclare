using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericScale : ValidationCheck<IComparable>
    {
        public NumericScale(IComparable value, int maxDecimalPlaces)
            : base(value)
        {
            _maxDecimalPlaces = maxDecimalPlaces;
        }

        private readonly int _maxDecimalPlaces;

        protected internal override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}