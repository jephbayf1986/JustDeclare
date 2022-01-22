namespace JustDeclare.Main.ValidationChecks
{
    internal class StringBlank : ValidationCheck<string>
    {
        public StringBlank(string value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, which {ShouldBeBlank}.";

        protected override bool GetTestResult()
            => string.IsNullOrWhiteSpace(ValueProvided);
    }
}