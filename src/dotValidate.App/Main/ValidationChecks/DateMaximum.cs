using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DateMaximum : ValidationCheck<DateTime?>
    {
        public DateMaximum(DateTime? value, DateTime maxDate) 
            : base(value)
        {
            _maxDate = maxDate;
        }

        private readonly DateTime _maxDate;

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
