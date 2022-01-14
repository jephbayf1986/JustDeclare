namespace JustDeclare.Main.ValidationChecks
{
    internal class NotNull : ValidationCheck<object>
    {
        public NotNull(object value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"No value was provided for {PropertyName}, which is a required field.";

        protected override bool GetTestResult()
            => ValueProvided != null;
    }
}