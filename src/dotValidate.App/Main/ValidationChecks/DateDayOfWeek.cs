using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DateDayOfWeek : ValidationCheck<DateTime?>
    {
        public DateDayOfWeek(DateTime? value, DayOfWeek dayOfWeek) 
            : base(value)
        {
            _dayOfWeek = dayOfWeek;
        }

        private readonly DayOfWeek _dayOfWeek;

        protected internal override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}