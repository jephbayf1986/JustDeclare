using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateYearRange : ValidationCheck<DateTime?>
    {
        public DateYearRange(DateTime? value, int rangeStart, int rangeEnd)
            : base(value)
        {
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
        }

        private readonly int _rangeStart;
        private readonly int _rangeEnd;

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
