using JustDeclare.Models;
using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NumericMinimum<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable
    {
        public NumericMinimum(TValue? value, IComparable minValue)
            : base(value)
        {
            _minValue = minValue;
        }

        private IComparable _minValue;

        protected override string DefaultRuleBreakDescription
            => $"A value of {ValueProvided} was provided for {PropertyName}, but the lowest allowed value is {_minValue}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            return _minValue.CompareTo(ValueProvided.Value) <= 0;
        }
    }
}