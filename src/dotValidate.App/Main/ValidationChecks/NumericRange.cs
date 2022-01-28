using dotValidate.Main.Helpers;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericRange<TValue, TMinimum, TMaximum> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
        where TMinimum : struct, IComparable, IConvertible, IFormattable
        where TMaximum : struct, IComparable, IConvertible, IFormattable
    {
        public NumericRange(TValue? value, TMinimum rangeStart, TMaximum rangeEnd) 
            : base(value)
        {
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
        }

        private readonly TMinimum _rangeStart;
        private readonly TMaximum _rangeEnd;

        protected override string DefaultRuleBreakDescription 
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this {Should} fall within the range of between {_rangeStart} and {_rangeEnd}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            var startCompatible = _rangeStart.TryChangeType(out TValue rangeStart);
            var endCompatible = _rangeEnd.TryChangeType(out TValue rangeEnd);

            if (!(startCompatible && endCompatible))
                return false;

            if (rangeEnd.CompareTo(ValueProvided.Value) <= 0)
                return false;

            return rangeStart.CompareTo(ValueProvided.Value) <= 0;
        }
    }
}