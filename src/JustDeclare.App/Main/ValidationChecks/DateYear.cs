using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateYear : ValidationCheck<DateTime?>
    {
        public DateYear(DateTime? value, int year) 
            : base(value)
        {
            _year = year;
        }

        private readonly int _year;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
