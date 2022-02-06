using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NumericZero<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable, IConvertible, IFormattable
    {
        public NumericZero(TValue? value)
            : base(value)
        {
        }

        protected internal override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} {Should} be equal to zero but {(Invert ? "was" : $"was {ValueProvidedDisplay}")}";

        protected internal override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            return Convert.ToDouble(ValueProvided.Value) == 0;
        }
    }
}
