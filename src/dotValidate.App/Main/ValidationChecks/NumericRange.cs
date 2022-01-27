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
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this {Should} fall within the range of between {_rangeStart} and {_rangeEnd}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            if (_rangeEnd.CompareTo(ValueProvided.Value) <= 0)
                return false;

            return _rangeStart.CompareTo(ValueProvided.Value) <= 0;
        }
    }
}