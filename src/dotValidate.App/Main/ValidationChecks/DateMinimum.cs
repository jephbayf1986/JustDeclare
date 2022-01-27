using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DateMinimum : ValidationCheck<DateTime?>
    {
        public DateMinimum(DateTime? value, DateTime minDate)
            : base(value)
        {
            _minDate = minDate;
        }

        private readonly DateTime _minDate;

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}