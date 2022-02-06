using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DateYear : ValidationCheck<DateTime?>
    {
        public DateYear(DateTime? value, int year) 
            : base(value)
        {
            _year = year;
        }

        private readonly int _year;

        protected internal override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
