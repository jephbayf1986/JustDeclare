namespace dotValidate.Main.ValidationChecks
{
    internal class StringBlank : ValidationCheck<string>
    {
        public StringBlank(string value)
            : base(value)
        {
        }

        protected internal override string DefaultRuleBreakDescription
            => $"A value of {ValueProvidedDisplay} was provided for {PropertyName}, which {ShouldBeBlank}.";

        protected internal override bool GetTestResult()
            => string.IsNullOrWhiteSpace(ValueProvided);
    }
}