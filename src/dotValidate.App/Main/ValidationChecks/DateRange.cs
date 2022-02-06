using System;

namespace dotValidate.Main.ValidationChecks
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

        protected internal override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}