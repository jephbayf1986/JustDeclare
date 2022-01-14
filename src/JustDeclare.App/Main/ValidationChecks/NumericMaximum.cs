using JustDeclare.Models;
using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NumericMaximum<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable
    {
        public NumericMaximum(TValue? value, IComparable maxValue)
            : base(value)
        {
            _maxValue = maxValue;
        }

        private readonly IComparable _maxValue;

        protected override string DefaultRuleBreakDescription
            => $"A value of {ValueProvided} was provided for {PropertyName}, but the highest allowed value is {_maxValue}.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return true;

            return _maxValue.CompareTo(ValueProvided.Value) >= 0;
        }
    }
}