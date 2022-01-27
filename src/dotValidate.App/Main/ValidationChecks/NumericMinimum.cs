using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericMinimum<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
    {
        public NumericMinimum(TValue? value, IComparable minValue)
            : base(value)
        {
            _minValue = minValue;
        }

        private readonly IComparable _minValue;

        protected override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this should be {GreaterThanOrEqualTo} {_minValue}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            return _minValue.CompareTo(ValueProvided.Value) <= 0;
        }
    }
}