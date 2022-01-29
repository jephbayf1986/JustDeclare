using dotValidate.Exceptions;
using dotValidate.Main.Helpers;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericMaximum<TValue, TMaximum> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
        where TMaximum : struct, IComparable, IConvertible, IFormattable
    {
        public NumericMaximum(TValue? value, TMaximum maxValue)
            : base(value)
        {
            _maxValue = maxValue;
        }

        private readonly TMaximum _maxValue;

        protected override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this should be {LessThanOrEqualTo} {_maxValue}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return true;

            var compatible = _maxValue.TryChangeType(out TValue maxValue);

            if (compatible)
                return maxValue.CompareTo(ValueProvided.Value) >= 0;

            compatible = ValueProvided.Value.TryChangeType(out TMaximum valueAsMaxType);

            if (compatible)
                return _maxValue.CompareTo(valueAsMaxType) >= 0;

            throw ValidationArgumentException.IncompatibleNumericArguments(PropertyName, ValueProvided, _maxValue, LessThanOrEqualTo);
        }
    }
}