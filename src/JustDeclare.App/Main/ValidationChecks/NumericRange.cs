using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NumericRange<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
    {
        public NumericRange(TValue? value, IComparable rangeStart, IComparable rangeEnd) 
            : base(value)
        {
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
        }

        private readonly IComparable _rangeStart;
        private readonly IComparable _rangeEnd;

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}