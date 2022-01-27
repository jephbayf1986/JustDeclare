namespace dotValidate.Main.ValidationChecks
{
    internal class Null : ValidationCheck<object>
    {
        public Null(object value)
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription
            => $"A value {Was} provided for {PropertyName}, which {ShouldBeNull}";

        protected override bool GetTestResult()
            => ValueProvided == null;
    }
}