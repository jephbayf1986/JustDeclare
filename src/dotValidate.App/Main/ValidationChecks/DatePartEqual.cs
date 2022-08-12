using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class DatePartEqual : ValidationCheck<DateTime?>
    {
        public DatePartEqual(DateTime? value, DateTime target)
            : base(value)
        {
            _target = target;
        }

        private readonly DateTime _target;

        protected internal override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} was {ValueProvided?.ToShortDateString() ?? "null"}, but {Should} fall on the same date as '{_target.ToShortDateString()}'.";

        protected internal override bool GetTestResult()
        {
            if (!ValueProvided.HasValue)
                return false;

            return _target.Date == ValueProvided?.Date;
        }
    }
}