using dotValidate.Exceptions;
using dotValidate.Main.Helpers;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericRange<TValue, TRangeStart, TRangeEnd> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
        where TRangeStart : struct, IComparable, IConvertible, IFormattable
        where TRangeEnd : struct, IComparable, IConvertible, IFormattable
    {
        public NumericRange(TValue? value, TRangeStart rangeStart, TRangeEnd rangeEnd) 
            : base(value)
        {
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
        }

        private readonly TRangeStart _rangeStart;
        private readonly TRangeEnd _rangeEnd;

        protected internal override string DefaultRuleBreakDescription 
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, but this {Should} fall within the range of between {_rangeStart} and {_rangeEnd}.";

        protected internal override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            var compatible = _rangeEnd.TryChangeType(out TValue rangeEnd);

            if (compatible)
            {
                if (rangeEnd.CompareTo(ValueProvided.Value) < 0)
                    return false;
            }
            else
            {
                compatible = ValueProvided.Value.TryChangeType(out TRangeEnd valueAsRangeEndType);

                if (compatible)
                {
                    if (_rangeEnd.CompareTo(valueAsRangeEndType) < 0)
                        return false;
                }
                else
                {
                    throw ValidationArgumentException.IncompatibleNumericArguments(PropertyName, ValueProvided, _rangeEnd, "Range");
                }
            }

            compatible = _rangeStart.TryChangeType(out TValue rangeStart);

            if (compatible)
            {
                return rangeStart.CompareTo(ValueProvided.Value) <= 0;
            }
            else
            {
                compatible = ValueProvided.Value.TryChangeType(out TRangeStart valueAsRangeStartType);

                if (compatible)
                    return _rangeStart.CompareTo(valueAsRangeStartType) <= 0;
            }

            throw ValidationArgumentException.IncompatibleNumericArguments(PropertyName, ValueProvided, _rangeStart, LessThanOrEqualTo);
        }
    }
}