namespace JustDeclare.Main.ValidationChecks
{
    internal class NotBlank : ValidationCheck<string>
    {
        public NotBlank(string value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"No blank value was provided for {PropertyName}, which is a required field.";

        protected override bool GetTestResult()
            => !string.IsNullOrWhiteSpace(ValueProvided);
    }
}