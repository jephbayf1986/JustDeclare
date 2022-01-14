using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class NotZero<TValue> : ValidationCheck<TValue?>
        where TValue : struct, IComparable
    {
        public NotZero(TValue value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"The value provided for {PropertyName} was zero, and a non-zero number must be provided.";

        protected override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return true;

            return ValueProvided.Value.CompareTo(0) != 0;
        }
    }
}