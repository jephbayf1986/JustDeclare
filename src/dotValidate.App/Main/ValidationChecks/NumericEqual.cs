using dotValidate.Main.Helpers;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericEqual<TValue, TTarget> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IFormattable
        where TTarget : struct, IComparable, IConvertible, IFormattable
    {
        public NumericEqual(TValue? value, TTarget target)
            : base(value)
        {
            _target = target;
        }

        private readonly TTarget _target;

        protected internal override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but {Should} be equal to {_target}";

        protected internal override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            var compatible = _target.TryChangeType(out TValue target);

            if (!compatible)
                return false;

            return target.CompareTo(ValueProvided.Value) == 0;
        }
    }
}
