namespace JustDeclare.Main.ValidationChecks
{
    internal class StringMaximumLength : ValidationCheck<string>
    {
        public StringMaximumLength(string value, int maxLength)
            : base(value)
        {
            _maxLength = maxLength;
        }

        private readonly int _maxLength;

        protected override string DefaultRuleBreakDescription
            => GetRuleBreakMessage();

        private string GetRuleBreakMessage()
            => $"A value of {ValueProvidedDisplay}{NumberOfCharacters} was provided for {PropertyName}, but the longest allowed length is {_maxLength} characters.";

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return true;

            if (ValueProvided.Length > _maxLength)
                return false;

            return true;
        }
    }
}