using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DateEqualAnyTime : ValidationCheck<DateTime?>
    {
        public DateEqualAnyTime(DateTime? value, DateTime target)
            : base(value)
        {
            _target = target;
        }

        private readonly DateTime _target;

        protected override string DefaultRuleBreakDescription
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
