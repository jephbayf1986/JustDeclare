using dotValidate.Exceptions;
using dotValidate.Main.Helpers;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericMinimum<TValue, TMinimum> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
        where TMinimum : struct, IComparable, IConvertible, IFormattable
    {
        public NumericMinimum(TValue? value, TMinimum minValue)
            : base(value)
        {
            _minValue = minValue;
        }

        private readonly TMinimum _minValue;

        protected internal override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this should be {GreaterThanOrEqualTo} {_minValue}.";

        protected internal override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            var compatible = _minValue.TryChangeType(out TValue minValue);

            if (compatible)
                return minValue.CompareTo(ValueProvided.Value) <= 0;

            compatible = ValueProvided.Value.TryChangeType(out TMinimum valueAsMinType);

            if (compatible)
                return _minValue.CompareTo(valueAsMinType) <= 0;

            throw ValidationArgumentException.IncompatibleNumericArguments(PropertyName, ValueProvided, _minValue, GreaterThanOrEqualTo);
        }
    }
}