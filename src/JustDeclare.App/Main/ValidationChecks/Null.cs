namespace JustDeclare.Main.ValidationChecks
{
    internal class Null : ValidationCheck<object>
    {
        public Null(object value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"A value was provided for {PropertyName}, which should be null";

        protected override bool GetTestResult()
            => ValueProvided == null;
    }
}