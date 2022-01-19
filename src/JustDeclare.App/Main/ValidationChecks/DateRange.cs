using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateRange : ValidationCheck<DateTime?>
    {
        public DateRange(DateTime? value, DateTime rangeStart, DateTime rangeEnd) 
            : base(value)
        {
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
        }

        private readonly DateTime _rangeStart;
        private readonly DateTime _rangeEnd;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}