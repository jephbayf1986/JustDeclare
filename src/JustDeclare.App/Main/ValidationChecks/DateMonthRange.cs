using JustDeclare.Enums;
using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateMonthRange : ValidationCheck<DateTime?>
    {
        public DateMonthRange(DateTime? value, MonthOfYear rangeStart, MonthOfYear rangeEnd)
            : base(value)
        {
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
        }

        private readonly MonthOfYear _rangeStart;
        private readonly MonthOfYear _rangeEnd;

        protected override string DefaultRuleBreakDescription
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
