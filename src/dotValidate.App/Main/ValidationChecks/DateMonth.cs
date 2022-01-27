using JustDeclare.Enums;
using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateMonth : ValidationCheck<DateTime?>
    {
        public DateMonth(DateTime? value, MonthOfYear month)
            : base(value)
        {
            _month = month;
        }

        private readonly MonthOfYear _month;

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
