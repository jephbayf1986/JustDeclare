using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateWeekDay : ValidationCheck<DateTime?>
    {
        public DateWeekDay(DateTime? value) 
            : base(value)
        {
        }

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
