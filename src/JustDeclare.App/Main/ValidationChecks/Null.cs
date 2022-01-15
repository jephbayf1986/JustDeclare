namespace JustDeclare.Main.ValidationChecks
{
    internal class Null : ValidationCheck<object>
    {
        public Null(object value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"No value was provided for {PropertyName}, which is a required field.";

        protected override bool GetTestResult()
            => ValueProvided == null;
    }
}