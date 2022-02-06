using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DateEqualAnyTime : ValidationCheck<DateTime?>
    {
        public DateEqualAnyTime(DateTime? value, DateTime target)
            : base(value)
        {
            _target = target;
        }

        private readonly DateTime _target;

        protected internal override string DefaultRuleBreakDescription
            => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
