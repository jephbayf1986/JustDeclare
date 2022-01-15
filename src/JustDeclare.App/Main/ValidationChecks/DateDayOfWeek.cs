using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateDayOfWeek : ValidationCheck<DateTime>
    {
        public DateDayOfWeek(DateTime value, DayOfWeek dayOfWeek) 
            : base(value)
        {
            _dayOfWeek = dayOfWeek;
        }

        private readonly DayOfWeek _dayOfWeek;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}