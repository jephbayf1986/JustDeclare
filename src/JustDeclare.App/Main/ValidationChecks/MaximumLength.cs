namespace JustDeclare.Main.ValidationChecks
{
    internal class MaximumLength : ValidationCheck<string>
    {
        public MaximumLength(string value, int maxLength)
            : base(value)
        {
            _maxLength = maxLength;
        }

        private readonly int _maxLength;

        protected override string DefaultRuleBreakDescription
            => GetRuleBreakMessage();

        private string GetRuleBreakMessage()
        {
            var length = ValueProvided.Length;

            if (length < 11)
                return $"A value of '{ValueProvided}' ({length} characters) was provided for {PropertyName}, but the longest allowed length is {_maxLength} characters.";

            return $"A value of '{ValueProvided.Substring(0, 10)}...' ({length} characters) was provided for {PropertyName}, but the longest allowed length is {_maxLength} characters.";
        }

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