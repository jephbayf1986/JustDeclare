namespace dotValidate.Main.ValidationChecks
{
    internal class StringMinimumLength : ValidationCheck<string>
    {
        public StringMinimumLength(string value, int minLength)
            : base(value)
        {
            _minLength = minLength;
        }

        private readonly int _minLength;

        protected override string DefaultRuleBreakDescription
            => GetRuleBreakMessage();

        private string GetRuleBreakMessage()
            => $"A value of {ValueProvidedDisplay}{NumberOfCharacters} was provided for {PropertyName}, but the shortest allowed length is {_minLength} characters.";

        protected override bool GetTestResult()
        {
            if (ValueProvided == null)
                return false;

            if (ValueProvided.Length < _minLength)
                return false;

            return true;
        }
    }
}