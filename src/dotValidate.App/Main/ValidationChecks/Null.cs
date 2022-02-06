namespace dotValidate.Main.ValidationChecks
{
    internal class Null : ValidationCheck<object>
    {
        public Null(object value)
            : base(value)
        {
        }

        protected internal override string DefaultRuleBreakDescription
            => $"A value {Was} provided for {PropertyName}, which {ShouldBeNull}";

        protected internal override bool GetTestResult()
            => ValueProvided == null;
    }
}