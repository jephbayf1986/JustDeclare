using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NumericZero<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IConvertible
    {
        public NumericZero(TValue? value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} {Should} be equal to zero but {(Invert ? "was" : $"was {ValueProvidedDisplay}")}";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            return Convert.ToDouble(ValueProvided.Value) == 0;
        }
    }
}
