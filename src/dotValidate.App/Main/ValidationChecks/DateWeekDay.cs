using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DateWeekDay : ValidationCheck<DateTime?>
    {
        public DateWeekDay(DateTime? value) 
            : base(value)
        {
        }

        protected internal override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
