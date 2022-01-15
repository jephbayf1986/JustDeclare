namespace JustDeclare.Main.ValidationChecks
{
    internal class StringBlank : ValidationCheck<string>
    {
        public StringBlank(string value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"No blank value was provided for {PropertyName}, which is a required field.";

        protected override bool GetTestResult()
            => !string.IsNullOrWhiteSpace(ValueProvided);
    }
}