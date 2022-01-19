using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NumericEqual<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable
    {
        public NumericEqual(TValue? value, IComparable target)
            : base(value)
        {
            _target = target;
        }

        private readonly IComparable _target;

        protected override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} was {ValueProvidedDisplay}, but {Should} be equal to {_target}";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            return _target.CompareTo(ValueProvided.Value) == 0;
        }
    }
}
