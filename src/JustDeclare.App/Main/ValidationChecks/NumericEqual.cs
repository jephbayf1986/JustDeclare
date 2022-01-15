using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NumericEqual<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable
    {
        public NumericEqual(TValue? value, IComparable maxValue)
            : base(value)
        {
            _maxValue = maxValue;
        }

        private readonly IComparable _maxValue;

        protected override string DefaultRuleBreakDescription
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
