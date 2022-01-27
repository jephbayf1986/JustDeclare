using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericMaximum<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
    {
        public NumericMaximum(TValue? value, IComparable maxValue)
            : base(value)
        {
            _maxValue = maxValue;
        }

        private readonly IComparable _maxValue;

        protected override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this should be {LessThanOrEqualTo} {_maxValue}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return true;

            return _maxValue.CompareTo(ValueProvided.Value) >= 0;
        }
    }
}